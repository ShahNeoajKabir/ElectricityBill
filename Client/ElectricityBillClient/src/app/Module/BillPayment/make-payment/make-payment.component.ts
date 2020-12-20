import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PaymentMethod } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Payment } from '../../../Model/Payment';
import { VMPayment } from '../../../Model/VMPayment';
import { PaymentService } from '../../../Service/Payment/payment.service';

@Component({
  selector: 'app-make-payment',
  templateUrl: './make-payment.component.html',
  styleUrls: ['./make-payment.component.css']
})
export class MakePaymentComponent implements OnInit {
  public objpayment:Payment=new Payment();
  public lstpaymnetmethod:any;
  public BillId:any;
  public vmpayment:VMPayment=new VMPayment();

  constructor(private utility:Utility,private router:Router, private activateroute:ActivatedRoute, private paymentservice:PaymentService) { }

  ngOnInit(): void {
    this.lstpaymnetmethod=this.utility.enumToArray(PaymentMethod);
    

    if (this.activateroute.snapshot.params[ 'id'] !== undefined) {
      this.BillId = this.activateroute.snapshot.params[ 'id'];
      this.paymentservice.GetPayment(this.BillId).subscribe((res: any) => {
        this.vmpayment = res;
        console.log(this.vmpayment);
      });
      console.log(this.activateroute.snapshot.params[ 'id']);
    }
  }

}
