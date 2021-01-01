import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PaymentMethod } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { CardInformation } from '../../../Model/CardInformation';
import { MobileBanking } from '../../../Model/MobileBanking';
import { Payment } from '../../../Model/Payment';
import { VMMakePayment, VMPayment } from '../../../Model/VMPayment';
import { PaymentService } from '../../../Service/Payment/payment.service';
import { PaymentGetwayService } from '../../../Service/PaymentGetway/payment-getway.service';

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
    this.vmmakepayment.CustomerId=this.BillId;
    // document.getElementById('ExpiredDate');
     if(this.vmmakepayment.PaymentMethod==1){
       this.paymentgetwayservice.GetCard(this.vmmakepayment.cardinformation).subscribe((res:any)=>{
        
         if(res!=null){
          this.cardinformation=res;
          if(this.cardinformation.Balance<this.vmpayment.BillAmount){
            alert("Insuficient balance");
          }
          else{
            
          }
         }
         console.log(this.cardinformation);
       })

     }
     else{
       this.vmmakepayment.mobilebanking.MobileBankingType= this.vmmakepayment.PaymentMethod;
       this.paymentgetwayservice.GetMobileBanking(this.vmmakepayment.mobilebanking).subscribe((res:any)=>{
        if(res!=null){
          this.mobilebanking=res;
          if(this.mobilebanking.Balance<this.vmpayment.BillAmount){
            alert("Insuficient balance");
          }
          else{
            
          }
         }
         console.log(this.mobilebanking);
       })
     }
    console.log(this.ExpiredDate);
  }

}
