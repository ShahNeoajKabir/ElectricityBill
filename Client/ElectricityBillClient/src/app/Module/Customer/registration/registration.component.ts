import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Blood, CustomerType, Gender, Nationality, Religion } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Customer } from '../../../Model/Customer';
import { Zone } from '../../../Model/Zone';
import { CustomerService } from '../../../Service/Customer/customer.service';
import { ZoneService } from '../../../Service/Zone/zone.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  public registration:Customer=new Customer();
  public lstGender:any;
  public lstreligion:any;
  public lstcutomertype:any;
  public lstblood:any;
  public lstnationality:any;
  public  lstzone:Zone[]=new Array<Zone>();
  public objedit:Customer=new Customer();

  constructor(private utility:Utility, private customerservice:CustomerService,private router:Router, private ActiveRouter:ActivatedRoute,private zoneservice:ZoneService) { }

  ngOnInit(): void {
    this.lstGender=this.utility.enumToArray(Gender);
    this.lstreligion=this.utility.enumToArray(Religion);
    this.lstcutomertype=this.utility.enumToArray(CustomerType);
    this.lstblood=this.utility.enumToArray(Blood);
    this.lstnationality=this.utility.enumToArray(Nationality);

    this.zoneservice.GetAll().subscribe((res:any)=>{
      this.lstzone=res;
      console.log(this.lstzone);

    });



    if (this.ActiveRouter.snapshot.params['id'] !== undefined) {

      this.objedit.CustomerId = this.ActiveRouter.snapshot.params['id' ];
      this.customerservice.GetById(this.objedit).subscribe(( res: any) => {

        this.registration = res;
        console.log(this.registration);
     });
      console.log(this.ActiveRouter.snapshot.params['id' ] );

    }

  }
  AddCustomer(){
    console.log(this.registration);
    if (this.registration.CustomerId > 0 ) {
      this.customerservice.UpdateUser(this.registration).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/User/View']);
          console.log(res);
        }
        console.log(res);
      } );
    } else {
      this.customerservice.AddCustomer(this.registration).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/User/View']);
          console.log(res);
        }
        console.log(res);
      } );
    }

  }

}
