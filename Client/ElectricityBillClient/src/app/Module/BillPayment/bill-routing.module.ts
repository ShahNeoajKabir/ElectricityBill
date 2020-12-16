import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';import { BillPaymentComponent } from './bill-payment/bill-payment.component';
;


const routes: Routes = [
{ path: 'View', component: BillPaymentComponent },


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BillRoutingModule { }
