import { Component, OnInit } from '@angular/core';
import { CustomerType, Gender, Religion } from 'src/app/Common/Enum';
import { Utility } from 'src/app/Common/Utility';
import { Customer } from 'src/app/Model/Customer';

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

  constructor(private utility:Utility) { }

  ngOnInit(): void {
    this.lstGender=this.utility.enumToArray(Gender);
    this.lstreligion=this.utility.enumToArray(Religion);
    this.lstcutomertype=this.utility.enumToArray(CustomerType);
  }

}

