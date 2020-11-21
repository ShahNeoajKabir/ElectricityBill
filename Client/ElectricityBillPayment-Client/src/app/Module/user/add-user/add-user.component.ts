import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Gender, Status, UserType } from 'src/app/Common/Enum';
import { Utility } from 'src/app/Common/Utility';
import { User } from 'src/app/Model/User';
import { UserService } from 'src/app/Service/User/user.service';

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
  public objuseredit: User = new User();
  constructor(
    private userservice:UserService,
    private router: Router,
    private ActivateRouter: ActivatedRoute,
    private utility:Utility
  ) { }

  ngOnInit(): void {
    this.lstStatus = this.utility.enumToArray(Status);
    this.lstGender = this.utility.enumToArray(Gender);
    this.lstType=this.utility.enumToArray(UserType);

    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.objuseredit.UserId = this.ActivateRouter.snapshot.params['id' ];
      this.userservice.GetById(this.objuseredit).subscribe(( res: any) => {

        this.objUser = res;
        console.log(this.objUser);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }

  }


  AddUser(){
    console.log(this.objUser);
    if (this.objUser.UserId > 0 ) {
      this.userservice.UpdateUser(this.objUser).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/User/View']);
          console.log(res);
        }
        console.log(res);
      } );
    } else {
      this.userservice.AddUser(this.objUser).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/User/View']);
          console.log(res);
        }
        console.log(res);
      } );
    }


  }

}
