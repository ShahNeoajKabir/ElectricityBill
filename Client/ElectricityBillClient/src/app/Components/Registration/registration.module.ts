import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CustomerService } from '../../Service/Customer/customer.service';
import { RegisterComponent } from '../../views/register/register.component';
import { CustomerRegistrationComponent } from './customer-registration/customer-registration.component';
import { RegistrationRoutingModule } from './registration-routing.module';



@NgModule({
  declarations: [ CustomerRegistrationComponent],
  imports: [
    CommonModule,
    RegistrationRoutingModule,
    FormsModule
  ],
  providers:[CustomerService],
})
export class RegistrationModule { }
