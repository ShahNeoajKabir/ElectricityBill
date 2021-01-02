import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CustomerService } from '../../Service/Customer/customer.service';
import { RegisterComponent } from '../../views/register/register.component';
import { CustomerRegistrationComponent } from './customer-registration/customer-registration.component';
import { RegistrationRoutingModule } from './registration-routing.module';
import { AgmCoreModule } from '@agm/core';



@NgModule({
  declarations: [ CustomerRegistrationComponent],
  imports: [
    CommonModule,
    RegistrationRoutingModule,
    FormsModule,
    AgmCoreModule.forRoot({  
      apiKey: 'AIzaSyBib2Nuc4iRnft_GXCfAOSkobRbN7u-wJQ'  
    }),
  ],
  providers:[CustomerService],
})
export class RegistrationModule { }
