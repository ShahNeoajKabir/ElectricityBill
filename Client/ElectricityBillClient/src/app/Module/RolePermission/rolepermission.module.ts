import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';;
import { FormsModule } from '@angular/forms';
import { AddRolePermissionComponent } from './add-role-permission/add-role-permission.component';
import { AddUrlComponent } from './add-url/add-url.component';
import { RolePermissionService } from '../../Service/RolePermission/role-permission.service';
import { RolePermissionRoutingModule } from './rolepermission-routing.module';



@NgModule({
  declarations: [AddRolePermissionComponent, AddUrlComponent],
  imports: [
    CommonModule,
    RolePermissionRoutingModule,
    FormsModule
  ],
  providers:[RolePermissionService],
})
export class RolePermissionModule { }
