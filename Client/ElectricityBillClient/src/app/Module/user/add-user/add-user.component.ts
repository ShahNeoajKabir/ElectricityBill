import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status, Gender, UserType } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { User } from '../../../Model/User';
import { UserService } from '../../../Service/User/user.service';
import { ZoneService } from '../../../Service/Zone/zone.service';
import * as _ from 'lodash';
import { NotificationService } from '../../../Service/Notification/notification.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

 public objUser:User=new User();
  public lstStatus:any ;
  public lstGender:any;
  public lstType:any;
  public lstzone:any;
  public userid:any;
  public objuseredit: User = new User();
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;
  constructor(
    private userservice:UserService,
    private router: Router,
    private ActivateRouter: ActivatedRoute,
    private utility:Utility,
    private zoneservice:ZoneService,
    private notificationservice:NotificationService
  ) { }

  ngOnInit(): void {
    this.lstStatus = this.utility.enumToArray(Status);
    this.lstGender = this.utility.enumToArray(Gender);
    this.lstType=this.utility.enumToArray(UserType);
    this.zoneservice.GetAll().subscribe((res: any) => {
      console.log(res);

      this.lstzone = res;
      console.log(this.lstzone);

    });

    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.userid = this.ActivateRouter.snapshot.params['id' ];
      this.userservice.GetById(this.userid).subscribe(( res: any) => {

        // this.objUser = res;
        console.log(res);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }

  }


  AddUser(){
    console.log(this.objUser);
    if (this.objUser.UserId > 0 ) {
      this.userservice.UpdateUser(this.objUser).subscribe(res => {
       
        console.log(res);
        if(res){
          this.notificationservice.updateNotification("Successfully Updated");
          this.router.navigate(['/User/View']);
        }
      },er=>{
        this.notificationservice.ErrorNotification("Failed To Update");
          this.router.navigate(['/User/AddUser']);
      } );
    } else {
      this.userservice.AddUser(this.objUser).subscribe(res => {
        
        console.log(res);
        if(res){
          this.notificationservice.successNotification("User Added Successfully");
          this.router.navigate(['/User/View']);
        }
      },er=>{
        this.notificationservice.ErrorNotification("Failed To Added");
          this.router.navigate(['/User/AddUser']);

      } );
    }


  }
  fileChangeEvent(fileInput: any) {
    this.imageError = null;
    if (fileInput.target.files && fileInput.target.files[0]) {
        // Size Filter Bytes
        const max_size = 20971520;
        const allowed_types = ['image/png', 'image/jpeg'];
        const max_height = 15200;
        const max_width = 25600;
  
        if (fileInput.target.files[0].size > max_size) {
            this.imageError =
                'Maximum size allowed is ' + max_size / 1000 + 'Mb';
  
            return false;
        }
  
        if (!_.includes(allowed_types, fileInput.target.files[0].type)) {
            this.imageError = 'Only Images are allowed ( JPG | PNG )';
            return false;
        }
        const reader = new FileReader();
        reader.onload = (e: any) => {
            const image = new Image();
            image.src = e.target.result;
            image.onload = rs => {
                const img_height = rs.currentTarget['height'];
                const img_width = rs.currentTarget['width'];
  
                console.log(img_height, img_width);
  
  
                if (img_height > max_height && img_width > max_width) {
                    this.imageError =
                        'Maximum dimentions allowed ' +
                        max_height +
                        '*' +
                        max_width +
                        'px';
                    return false;
                } else {
                    const imgBase64Path = e.target.result;
                    this.cardImageBase64 = imgBase64Path;
                    this.isImageSaved = true;
                    this.objUser.Image = this.cardImageBase64;
                    // this.previewImagePath = imgBase64Path;
                }
            };
        };
  
        reader.readAsDataURL(fileInput.target.files[0]);
    }
  }
  
  removeImage() {
    this.cardImageBase64 = null;
    this.objUser.Image =  null;
    this.isImageSaved = false;
  }

}
