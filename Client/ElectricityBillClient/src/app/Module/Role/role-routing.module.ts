import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../Common/Auth/auth.guard';
import { AddRoleComponent } from './add-role/add-role.component';
import { ListRoleComponent } from './list-role/list-role.component';


const routes: Routes = [{ path: 'AddRole', component: AddRoleComponent  },
// { path: 'View', component: ListRoleComponent  ,canActivate: [AuthGuard]},
// { path: ':id/edit', component: AddRoleComponent  ,canActivate: [AuthGuard]}
{ path: 'View', component: ListRoleComponent  },
{ path: ':id/edit', component: AddRoleComponent  }





];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoleRoutingModule { }
