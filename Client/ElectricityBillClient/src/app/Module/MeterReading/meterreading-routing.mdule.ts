import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddMeterReadingComponent } from './add-meter-reading/add-meter-reading.component';
import { ListMeterReadingComponent } from './list-meter-reading/list-meter-reading.component';

const route: Routes =[
  { path: 'AddMeterReading', component: AddMeterReadingComponent},
  {path: 'View', component:ListMeterReadingComponent},
  {path:":id/edit",component:AddMeterReadingComponent}
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(route)],


  exports:[RouterModule]
})
export class MeterReadingRoutingModule { }
