import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ListCustomerComponent } from './list-customer/list-customer.component';
import { CustomerRoutingModule } from './customer-routing.modules';
import { CustomerService } from '../../Service/Customer/customer.service';
import { PendingCustomerComponent } from './pending-customer/pending-customer.component';
import { ModalModule } from 'ngx-bootstrap/modal';



@NgModule({
  declarations: [ ListCustomerComponent,PendingCustomerComponent],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    FormsModule,
    ModalModule.forRoot()
  ],
  providers:[CustomerService],
})
export class CustomerModule { }
