import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddSupportComponent } from './add-support/add-support.component';
import { ListSupportComponent } from './list-support/list-support.component';


const routes: Routes = [{ path: 'AddSupport', component: AddSupportComponent },
{ path: 'View', component: ListSupportComponent },
{path:':id/edit',component:AddSupportComponent}



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SupportRoutingModule { }
