import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../Common/Auth/auth.guard';
import { AddUserRoleComponent } from './add-user-role/add-user-role.component';
import { ListUserRoleComponent } from './list-user-role/list-user-role.component';


const routes: Routes = [{ path: 'AddUserRole', component: AddUserRoleComponent },
{ path: 'View', component: ListUserRoleComponent  },
{path:':id/edit', component:AddUserRoleComponent }



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoleRoutingModule { }
