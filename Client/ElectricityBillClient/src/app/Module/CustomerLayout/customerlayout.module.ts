import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CustomerLayoutComponent } from './customer-layout/customer-layout.component';
import { CustomerService } from '../../Service/Customer/customer.service';
import { CustomerLayoutRoutingModule } from './customerlayout-routing.module';
import { BillHistroryComponent } from './bill-histrory/bill-histrory.component';
import { PaymentHistoryComponent } from './payment-history/payment-history.component';
import { ProfileComponent } from './profile/profile.component';



@NgModule({
  declarations: [CustomerLayoutComponent, BillHistroryComponent, PaymentHistoryComponent,ProfileComponent],
  imports: [
    CommonModule,
    CustomerLayoutRoutingModule,
    FormsModule
  ],
  providers:[CustomerService],
})
export class CustomerLayoutModule { }
