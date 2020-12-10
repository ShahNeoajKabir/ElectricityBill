import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddZoneAssignComponent } from './add-zone-assign/add-zone-assign.component';
import { ListZoneAssignComponent } from './list-zone-assign/list-zone-assign.component';



const routes: Routes = [{ path: 'AssignZone', component: AddZoneAssignComponent },
{ path: 'View', component: ListZoneAssignComponent },
{path:':id/edit', component:AddZoneAssignComponent}



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ZoneAssignRoutingModule { }
