import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SupportService } from 'src/app/Service/Support/support.service';
import { AddSupportComponent } from './add-support/add-support.component';
import { ListSupportComponent } from './list-support/list-support.component';


const routes: Routes = [{ path: 'AddSupport', component: AddSupportComponent },
{ path: '', component: ListSupportComponent }



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SupportRoutingModule { }
