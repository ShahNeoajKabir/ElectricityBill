import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddZoneComponent } from './add-zone/add-zone.component';
import { ListZoneComponent } from './list-zone/list-zone.component';



const routes: Routes = [{ path: 'AddZone', component: AddZoneComponent },
{ path: 'View', component: ListZoneComponent },
{path:':id/edit', component:AddZoneComponent}



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ZoneRoutingModule { }
