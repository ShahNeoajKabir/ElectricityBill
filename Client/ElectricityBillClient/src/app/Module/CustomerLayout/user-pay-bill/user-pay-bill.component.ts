import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PaymentMethod } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { CardInformation } from '../../../Model/CardInformation';
import { MobileBanking } from '../../../Model/MobileBanking';
import { Payment } from '../../../Model/Payment';
import { VMMakePayment, VMPayment } from '../../../Model/VMPayment';
import { PaymentService } from '../../../Service/Payment/payment.service';
import { PaymentGetwayService } from '../../../Service/PaymentGetway/payment-getway.service';

@Component({
  selector: 'app-user-pay-bill',
  templateUrl: './user-pay-bill.component.html',
  styleUrls: ['./user-pay-bill.component.css']
})
export class UserPayBillComponent implements OnInit {

  public objpayment:Payment=new Payment();
  public lstpaymnetmethod:any;
  public BillId:any;
  
  public vmpayment:VMPayment=new VMPayment();
  public ExpiredDate:Date;
  public vmmakepayment:VMMakePayment=new VMMakePayment();
  public mobilebanking:MobileBanking=new MobileBanking();
  public cardinformation:CardInformation=new CardInformation();

  constructor(private utility:Utility,private router:Router, private activateroute:ActivatedRoute, private paymentservice:PaymentService ,private paymentgetwayservice:PaymentGetwayService) { }

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

  Save(){
    this.vmmakepayment.BillId=this.vmpayment.BillId;
    
    this.paymentservice.MakePayment(this.vmmakepayment).subscribe(res=>{
      console.log(res);
    });
  }

}
