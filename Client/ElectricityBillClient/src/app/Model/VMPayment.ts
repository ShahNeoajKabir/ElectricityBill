import { CardInformation } from "./CardInformation";
import { MobileBanking } from "./MobileBanking";

export class VMPayment{
        MeterNumber:string;
        CustomeName:string;
        Email:string;
        CurrentUnit:number;
        PreviousUnit:number;
        UsesUnit:number;
        CustomerId:number;
        MeterId:number;

        Vat:number;
        TotalBillAmount:number
        BillAmount:number;
}
export class VMMakePayment{
        BillId:number;
        CustomerId:number;
        MeterId:number;
        PaymentMethod:number;
        cardinformation:CardInformation;
        mobilebanking:MobileBanking;
        RequestAmount:number;
        constructor(){
         this.cardinformation =new CardInformation();
         this.mobilebanking=new MobileBanking();
        }

}