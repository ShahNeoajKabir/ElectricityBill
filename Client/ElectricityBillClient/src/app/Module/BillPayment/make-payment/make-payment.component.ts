import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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

  constructor(private utility:Utility,private router:Router, private activateroute:ActivatedRoute) { }

  ngOnInit(): void {
    this.lstpaymnetmethod=this.utility.enumToArray(PaymentMethod);
    

    if (this.activateroute.snapshot.params[ 'id'] !== undefined) {
      this.objpayment.BillId = this.activateroute.snapshot.params[ 'id'];
      // this.meterassignservice.GetById(this.objedit).subscribe((res: any) => {
      //   this.lstmeterassign = res;
      //   console.log(this.lstmeterassign);
      // });
      console.log(this.activateroute.snapshot.params[ 'id']);
    }
  }

}
