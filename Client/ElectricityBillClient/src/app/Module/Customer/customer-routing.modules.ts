import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutModule } from '@coreui/angular/lib/shared/layout/layout.module';

import { ListCustomerComponent } from './list-customer/list-customer.component';
import { PendingCustomerComponent } from './pending-customer/pending-customer.component';


const routes: Routes = [
{ path: 'View', component: ListCustomerComponent },
{ path: 'PendingCustomer', component: PendingCustomerComponent },



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
