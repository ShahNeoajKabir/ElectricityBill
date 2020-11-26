import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AssignMeterComponent } from './assign-meter/assign-meter.component';
import { ListAssignMeterComponent } from './list-assign-meter/list-assign-meter.component';

const route: Routes =[
  { path: 'AddAssignMeter', component: AssignMeterComponent},
  {path: 'View', component:ListAssignMeterComponent},
  {path: ':id/edit', component:AssignMeterComponent}

]

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(route)],


  exports:[RouterModule]
})
export class AssignMeterRoutingModule { }
