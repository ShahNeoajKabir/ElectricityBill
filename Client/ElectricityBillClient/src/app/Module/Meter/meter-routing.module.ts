import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../Common/Auth/auth.guard';
import { AddMeterComponent } from './add-meter/add-meter.component';
import { ListMeterComponent } from './list-meter/list-meter.component';


const routes: Routes = [{ path: 'AddMeter', component: AddMeterComponent  },
{ path: 'View', component: ListMeterComponent  },
{path:':id/editmeter',component:AddMeterComponent }



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MeterRoutingModule { }
