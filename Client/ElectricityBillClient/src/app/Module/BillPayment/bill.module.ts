import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BillTableService } from '../../Service/BillTable/bill-table.service';
import { BillPaymentComponent } from './bill-payment/bill-payment.component';
import { BillRoutingModule } from './bill-routing.module';
import { MakePaymentComponent } from './make-payment/make-payment.component';
import { PaymentService } from '../../Service/Payment/payment.service';
import { PaymentHistoryComponent } from './payment-history/payment-history.component';



@NgModule({
  declarations: [ BillPaymentComponent, MakePaymentComponent, PaymentHistoryComponent],
  imports: [
    CommonModule,
    BillRoutingModule,
    FormsModule
  ],
  providers:[BillTableService,PaymentService],
})
export class BillModule { }
