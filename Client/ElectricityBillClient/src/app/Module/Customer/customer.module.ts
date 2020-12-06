import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ListCustomerComponent } from './list-customer/list-customer.component';
import { CustomerRoutingModule } from './customer-routing.modules';
import { CustomerLayoutComponent } from './customer-layout/customer-layout.component';
import { CustomerService } from '../../Service/Customer/customer.service';



@NgModule({
  declarations: [ ListCustomerComponent, CustomerLayoutComponent],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    FormsModule
  ],
  providers:[CustomerService],
})
export class CustomerModule { }
