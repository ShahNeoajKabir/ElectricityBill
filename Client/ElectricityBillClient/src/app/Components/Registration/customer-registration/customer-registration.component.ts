import { MapsAPILoader } from '@agm/core';
import { Component, NgZone, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Blood, CustomerType, Gender, Nationality, Religion } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Customer } from '../../../Model/Customer';
import { Zone } from '../../../Model/Zone';
import { CustomerService } from '../../../Service/Customer/customer.service';
import { NotificationService } from '../../../Service/Notification/notification.service';
import { ZoneService } from '../../../Service/Zone/zone.service';

@Component({
  selector: 'app-customer-registration',
  templateUrl: './customer-registration.component.html',
  styleUrls: ['./customer-registration.component.css']
})
export class CustomerRegistrationComponent implements OnInit {

  public registration:Customer=new Customer();
  public lstGender:any;
  public lstreligion:any;
  public lstcutomertype:any;
  public lstblood:any;
  public lstnationality:any;
  public  lstzone:Zone[]=new Array<Zone>();
  public objedit:Customer=new Customer();
  ImageBaseData:string | ArrayBuffer=null;

  title: string = 'AGM project';
  latitude: number;
  longitude: number;
  zoom: number;
  address: string;
  private geoCoder;

  constructor(private mapsAPILoader: MapsAPILoader,private notificationservice:NotificationService,
    private ngZone: NgZone,private utility:Utility, private customerservice:CustomerService,private router:Router, private ActiveRouter:ActivatedRoute,private zoneservice:ZoneService) { }

  ngOnInit(): void {
      this.setCurrentLocation();

    // this.setCurrentLocation();
    // this.mapsAPILoader.load().then(() => {
    //   this.setCurrentLocation();
    //   this.geoCoder = new google.maps.Geocoder;

    // });
    this.lstGender=this.utility.enumToArray(Gender);
    this.lstreligion=this.utility.enumToArray(Religion);
    this.lstcutomertype=this.utility.enumToArray(CustomerType);
    this.lstblood=this.utility.enumToArray(Blood);
    this.lstnationality=this.utility.enumToArray(Nationality);

    this.zoneservice.GetAll().subscribe((res:any)=>{
      this.lstzone=res;

    });



    if (this.ActiveRouter.snapshot.params['id'] !== undefined) {

      this.objedit.CustomerId = this.ActiveRouter.snapshot.params['id' ];
      this.customerservice.GetById(this.objedit).subscribe(( res: any) => {

        this.registration = res;
     });
      console.log(this.ActiveRouter.snapshot.params['id' ] );

    }

  }
  AddCustomer(){
    console.log(this.registration);
    if (this.registration.CustomerId > 0 ) {
      this.customerservice.UpdateUser(this.registration).subscribe(res => {
        
          this.router.navigate(['/Login']);
          
        
        
      } );
    } else {
      this.customerservice.AddCustomer(this.registration).subscribe(res => {
        
          
          console.log(res);
          if(res){
            this.notificationservice.Massagereply("Registration Successful");
            this.router.navigate(['/Login']);
          }
        
      }, er=>{
        this.notificationservice.ErrorNotification();
        this.router.navigate(['/CustomerRegistration/Registration']);
      } );
    }

  }
  // Get Current Location Coordinates
  private setCurrentLocation() {
    if ('geolocation' in navigator) {
      navigator.geolocation.getCurrentPosition((position) => {
        console.log(position)
        this.registration.Latitude = position.coords.latitude;
        this.registration.Longitude = position.coords.longitude;
        this.zoom = 15;
      });
    }
  }

  handleFileInput(files: FileList) {
    let me = this;
    let file = files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
      console.log(reader.result);
      me.ImageBaseData=reader.result;
    };
    reader.onerror = function (error) {
      console.log('Error: ', error);
    };
 }
  btnUpload(){
    
    if(this.ImageBaseData==null){
      alert("Please select file");
    }else{     
      
      this.registration.Image=this.ImageBaseData.toString();
      
      
    }
  }


}
