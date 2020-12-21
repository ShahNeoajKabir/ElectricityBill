import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddRolePermissionComponent } from './add-role-permission/add-role-permission.component';
import { AddUrlComponent } from './add-url/add-url.component';


const routes: Routes = [{ path: 'AddUrl', component: AddUrlComponent },
{path:'AddRolePermission',component:AddRolePermissionComponent}





];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RolePermissionRoutingModule { }
