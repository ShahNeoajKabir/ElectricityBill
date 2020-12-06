import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerRegistrationComponent } from 'src/app/Component/customer-registration/customer-registration.component';

import { ListCustomerComponent } from './list-customer/list-customer.component';


const routes: Routes = [
{ path: 'View', component: ListCustomerComponent },
{path:':id/edit', component:CustomerRegistrationComponent}



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
