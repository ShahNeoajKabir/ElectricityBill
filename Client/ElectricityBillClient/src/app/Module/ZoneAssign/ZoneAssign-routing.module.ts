import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../Common/Auth/auth.guard';
import { AddZoneAssignComponent } from './add-zone-assign/add-zone-assign.component';
import { ListZoneAssignComponent } from './list-zone-assign/list-zone-assign.component';



const routes: Routes = [{ path: 'AssignZone', component: AddZoneAssignComponent ,canActivate: [AuthGuard]},
{ path: 'View', component: ListZoneAssignComponent ,canActivate: [AuthGuard] },
{path:':id/edit', component:AddZoneAssignComponent ,canActivate: [AuthGuard]}



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ZoneAssignRoutingModule { }
