import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddCardComponent } from './add-card/add-card.component';
import { ListCardComponent } from './list-card/list-card.component';

const route: Routes =[
  { path: 'AddCard', component: AddCardComponent},
  {path: 'View', component:ListCardComponent},
  {path:":id/edit",component:AddCardComponent}
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(route)],


  exports:[RouterModule]
})
export class CardRoutingModule { }
