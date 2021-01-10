import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../Common/Auth/auth.guard';

import { AssignMeterComponent } from './assign-meter/assign-meter.component';
import { ListAssignMeterComponent } from './list-assign-meter/list-assign-meter.component';
import { ListMeterAssignforCustomerComponent } from './list-meter-assignfor-customer/list-meter-assignfor-customer.component';

const route: Routes =[
  { path: 'AddAssignMeter', component: AssignMeterComponent ,canActivate: [AuthGuard]},

  { path: ':id/AddAssignMeter', component: AssignMeterComponent ,canActivate: [AuthGuard]},
  {path: 'View', component:ListAssignMeterComponent ,canActivate: [AuthGuard]},
  {path: ':id/edit', component:AssignMeterComponent ,canActivate: [AuthGuard]},
  {path: 'CustomerMeter', component:ListMeterAssignforCustomerComponent ,canActivate: [AuthGuard]},


]

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(route)],


  exports:[RouterModule]
})
export class AssignMeterRoutingModule { }
