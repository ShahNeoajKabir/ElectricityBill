import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BillTable } from '../../../Model/BillTable';
import { BillTableService } from '../../../Service/BillTable/bill-table.service';

@Component({
  selector: 'app-bill-payment',
  templateUrl: './bill-payment.component.html',
  styleUrls: ['./bill-payment.component.css']
})
export class BillPaymentComponent implements OnInit {
  public lstbill:BillTable[]=new Array<BillTable>();


  constructor(private billtableservice:BillTableService) { }

  ngOnInit(): void {
    this.billtableservice.GetAll().subscribe((res:any)=>{
      this.lstbill=res;
      console.log(this.lstbill);
    });
  }

}
