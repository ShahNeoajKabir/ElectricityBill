import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../Common/Auth/auth.guard';
import { AddUnitPriceComponent } from './add-unit-price/add-unit-price.component';
import { ListUnitPriceComponent } from './list-unit-price/list-unit-price.component';


const routes: Routes = [{ path: 'AddUnitPrice', component: AddUnitPriceComponent  ,canActivate: [AuthGuard]},
{ path: 'View', component: ListUnitPriceComponent ,canActivate: [AuthGuard] },
{path:':id/edit', component:AddUnitPriceComponent ,canActivate: [AuthGuard]}





];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UnitPriceRoutingModule { }
