import { Component, OnInit } from '@angular/core';
import { Payment } from '../../../Model/Payment';
import { PaymentService } from '../../../Service/Payment/payment.service';

@Component({
  selector: 'app-payment-history',
  templateUrl: './payment-history.component.html',
  styleUrls: ['./payment-history.component.css']
})
export class PaymentHistoryComponent implements OnInit {
  public lstpayment:Payment[]=new Array<Payment>();

  constructor(private paymentservice:PaymentService) { }

  ngOnInit(): void {
    this.paymentservice.GetAll().subscribe((res:any)=>{
      this.lstpayment=res;
      console.log(this.lstpayment);
    })
  }

}
