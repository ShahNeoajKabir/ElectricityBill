import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BillTable } from '../../../Model/BillTable';
import { Customer } from '../../../Model/Customer';
import { BillTableService } from '../../../Service/BillTable/bill-table.service';
import { CustomerService } from '../../../Service/Customer/customer.service';

@Component({
  selector: 'app-bill-payment',
  templateUrl: './bill-payment.component.html',
  styleUrls: ['./bill-payment.component.css']
})
export class BillPaymentComponent implements OnInit {
  public lstbill:BillTable[]=new Array<BillTable>();
  public lstcustomer:Customer[]=new Array<Customer>();


  constructor(private billtableservice:BillTableService,private customersetvice:CustomerService) { }

  ngOnInit(): void {
    this.billtableservice.GetAll().subscribe((res:any)=>{
      this.lstbill=res;
      console.log(this.lstbill);
    });
    this.customersetvice.GetAll().subscribe((res:any)=>{
      this.lstcustomer=res;
      console.log(this.lstcustomer);
    });
  }

}
