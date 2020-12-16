import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddMobileBankingComponent } from './add-mobile-banking/add-mobile-banking.component';
import { ListMobileBankingComponent } from './list-mobile-banking/list-mobile-banking.component';
const route: Routes =[
  { path: 'AddMobile', component: AddMobileBankingComponent},
  {path: 'View', component:ListMobileBankingComponent},
  {path:":id/edit",component:AddMobileBankingComponent}
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(route)],


  exports:[RouterModule]
})
export class MobileBankingRoutingModule { }
