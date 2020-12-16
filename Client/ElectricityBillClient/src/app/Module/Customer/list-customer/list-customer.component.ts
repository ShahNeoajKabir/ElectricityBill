import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from '../../../Model/Customer';
import { CustomerService } from '../../../Service/Customer/customer.service';


@Component({
  selector: 'app-list-customer',
  templateUrl: './list-customer.component.html',
  styleUrls: ['./list-customer.component.css']
})
export class ListCustomerComponent implements OnInit {
  public lstcustomer:Customer[]=new Array<Customer>();

  public search:string="";

  constructor(private customerservice:CustomerService,private router:Router,private activatedroute:ActivatedRoute) { }

  ngOnInit(): void {
    this.customerservice.GetAll().subscribe((res:any)=>{
      this.lstcustomer=res;
      console.log(this.lstcustomer);
    })
  }

  Edit(id:any){
    console.log(id);
  }

  Search(){
    this.customerservice.Search(this.search).subscribe((res:any)=>{
      this.lstcustomer=res;
      console.log(this.lstcustomer);
    })
  }

}
