import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../Common/Auth/auth.guard';
import { AddUserComponent } from './add-user/add-user.component';
import { ListUserComponent } from './list-user/list-user.component';


const routes: Routes = [{ path: 'AddUser', component: AddUserComponent, canActivate: [AuthGuard] },
{ path: 'View', component: ListUserComponent , canActivate: [AuthGuard] },
{path:':id/edit', component:AddUserComponent ,canActivate: [AuthGuard]}





];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
