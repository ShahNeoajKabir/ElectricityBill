import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddMeterComponent } from './add-meter/add-meter.component';
import { ListMeterComponent } from './list-meter/list-meter.component';


const routes: Routes = [{ path: 'AddMeter', component: AddMeterComponent },
{ path: '', component: ListMeterComponent }



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MeterRoutingModule { }
