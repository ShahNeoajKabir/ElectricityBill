import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutModule } from '@coreui/angular/lib/shared/layout/layout.module';
import { BillHistroryComponent } from './bill-histrory/bill-histrory.component';
import { CustomerLayoutComponent } from './customer-layout/customer-layout.component';
import { PaymentHistoryComponent } from './payment-history/payment-history.component';
import { ProfileComponent } from './profile/profile.component';
import { UserPayBillComponent } from './user-pay-bill/user-pay-bill.component';


const routes: Routes = [
{ path: '', component: CustomerLayoutComponent ,
children:[
  { path: 'BillHistory', component: BillHistroryComponent },
{ path: 'Profile', component: ProfileComponent },
{ path: 'PaymentHistory', component: PaymentHistoryComponent },
{ path: ':id/MakePayment', component: UserPayBillComponent },


]
},






];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerLayoutRoutingModule { }
