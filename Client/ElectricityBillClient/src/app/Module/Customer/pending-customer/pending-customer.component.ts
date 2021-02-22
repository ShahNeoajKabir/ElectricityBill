import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from '../../../Model/Customer';
import { CustomerService } from '../../../Service/Customer/customer.service';
import { MeterAssignService } from '../../../Service/MeterAssign/meter-assign.service';

@Component({
  selector: 'app-pending-customer',
  templateUrl: './pending-customer.component.html',
  styleUrls: ['./pending-customer.component.css']
})
export class PendingCustomerComponent implements OnInit {
  public lstcustomer:Customer[]=new Array<Customer>();

  public search:string="";

  constructor(private customerservice:CustomerService,private router:Router,private activatedroute:ActivatedRoute,private assignmeter:MeterAssignService) { }

  ngOnInit(): void {
    this.customerservice.GetAllPendingCustomer().subscribe((res: any) => {

      this.lstcustomer = res;

    });
    
  }

  Edit(id:any){
    console.log(id);
  }

  Search(){
    this.customerservice.Search(this.search).subscribe((res:any)=>{
      this.lstcustomer=res;
    })
  }

}
