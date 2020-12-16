import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutModule } from '@coreui/angular/lib/shared/layout/layout.module';
import { CustomerLayoutComponent } from './customer-layout/customer-layout.component';

import { ListCustomerComponent } from './list-customer/list-customer.component';
import { RegistrationComponent } from './registration/registration.component';


const routes: Routes = [
{ path: 'View', component: ListCustomerComponent },
{ path: 'Registration', component: RegistrationComponent },
{ path: ':id/edit', component: RegistrationComponent },
{ path: 'Dashboard', component: CustomerLayoutComponent },


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
