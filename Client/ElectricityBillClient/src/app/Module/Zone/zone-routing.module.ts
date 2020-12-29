import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../Common/Auth/auth.guard';
import { AddZoneComponent } from './add-zone/add-zone.component';
import { ListZoneComponent } from './list-zone/list-zone.component';



const routes: Routes = [{ path: 'AddZone', component: AddZoneComponent,canActivate: [AuthGuard] },
{ path: 'View', component: ListZoneComponent,canActivate: [AuthGuard] },
{path:':id/edit', component:AddZoneComponent, canActivate: [AuthGuard]}



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ZoneRoutingModule { }
