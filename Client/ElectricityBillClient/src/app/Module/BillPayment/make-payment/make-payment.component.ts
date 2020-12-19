import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PaymentMethod } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Payment } from '../../../Model/Payment';

@Component({
  selector: 'app-make-payment',
  templateUrl: './make-payment.component.html',
  styleUrls: ['./make-payment.component.css']
})
export class MakePaymentComponent implements OnInit {
  public objpayment:Payment=new Payment();
  public lstpaymnetmethod:any;

  constructor(private utility:Utility,private router:Router) { }

  ngOnInit(): void {
    this.lstpaymnetmethod=this.utility.enumToArray(PaymentMethod);
  }

}
