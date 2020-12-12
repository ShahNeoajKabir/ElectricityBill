import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddUnitPriceComponent } from './add-unit-price/add-unit-price.component';
import { ListUnitPriceComponent } from './list-unit-price/list-unit-price.component';


const routes: Routes = [{ path: 'AddUnitPrice', component: AddUnitPriceComponent },
{ path: 'View', component: ListUnitPriceComponent },
{path:':id/edit', component:AddUnitPriceComponent}





];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UnitPriceRoutingModule { }
