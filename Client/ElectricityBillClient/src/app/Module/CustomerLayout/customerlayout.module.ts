import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CustomerLayoutComponent } from './customer-layout/customer-layout.component';
import { CustomerService } from '../../Service/Customer/customer.service';
import { CustomerLayoutRoutingModule } from './customerlayout-routing.module';
import { BillHistroryComponent } from './bill-histrory/bill-histrory.component';
import { PaymentHistoryComponent } from './payment-history/payment-history.component';
import { ProfileComponent } from './profile/profile.component';
import { UserPayBillComponent } from './user-pay-bill/user-pay-bill.component';
import { UserService } from '../../Service/User/user.service';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BillPaperViewComponent } from './bill-paper-view/bill-paper-view.component';



@NgModule({
  declarations: [CustomerLayoutComponent, BillHistroryComponent, PaymentHistoryComponent,ProfileComponent, UserPayBillComponent, BillPaperViewComponent],
  imports: [
    CommonModule,
    CustomerLayoutRoutingModule,
    FormsModule,
    ModalModule.forRoot()
  ],
  providers:[CustomerService,UserService],
})
export class CustomerLayoutModule { }
