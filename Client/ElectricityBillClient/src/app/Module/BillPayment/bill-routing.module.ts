import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';import { BillPaymentComponent } from './bill-payment/bill-payment.component';
import { MakePaymentComponent } from './make-payment/make-payment.component';
import { PaymentHistoryComponent } from './payment-history/payment-history.component';


const routes: Routes = [
{ path: 'View', component: BillPaymentComponent },
{ path: ':id/Payment', component: MakePaymentComponent },
{ path: 'PaimentHistory', component: PaymentHistoryComponent },




];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BillRoutingModule { }
