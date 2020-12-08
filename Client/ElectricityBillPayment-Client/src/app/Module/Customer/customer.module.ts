import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ListCustomerComponent } from './list-customer/list-customer.component';
import { CustomerService } from 'src/app/Service/Customer/customer.service';
import { CustomerRoutingModule } from './customer-routing.modules';
import { CustomerLayoutComponent } from './customer-layout/customer-layout.component';



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
