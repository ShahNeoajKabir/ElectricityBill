import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerType, Gender, Religion } from 'src/app/Common/Enum';
import { Utility } from 'src/app/Common/Utility';
import { Customer } from 'src/app/Model/Customer';
import { CustomerService } from 'src/app/Service/Customer/customer.service';

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
  public objedit:Customer=new Customer();

  constructor(private utility:Utility, private customerservice:CustomerService,private router:Router, private ActiveRouter:ActivatedRoute) { }

  ngOnInit(): void {
    this.lstGender=this.utility.enumToArray(Gender);
    this.lstreligion=this.utility.enumToArray(Religion);
    this.lstcutomertype=this.utility.enumToArray(CustomerType);

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

