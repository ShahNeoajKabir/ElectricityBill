import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from '../../../Model/Customer';
import { CustomerService } from '../../../Service/Customer/customer.service';

@Component({
  selector: 'app-pending-customer',
  templateUrl: './pending-customer.component.html',
  styleUrls: ['./pending-customer.component.css']
})
export class PendingCustomerComponent implements OnInit {
  public lstcustomer:Customer[]=new Array<Customer>();

  public search:string="";

  constructor(private customerservice:CustomerService,private router:Router,private activatedroute:ActivatedRoute) { }

  ngOnInit(): void {
    this.customerservice.GetAllPending().subscribe((res: any) => {
      console.log(res);

      this.lstcustomer = res;
      console.log(this.lstcustomer);

    });
    
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
