import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddRoleComponent } from './add-role/add-role.component';
import { ListRoleComponent } from './list-role/list-role.component';

import { RoleRoutingModule } from './role-routing.module';
import { RoleService } from '../../Service/Role/role.service';



@NgModule({
  declarations: [AddRoleComponent, ListRoleComponent],
  imports: [
    CommonModule,
    RoleRoutingModule,
    FormsModule
  ],
  providers:[RoleService],
})
export class RoleModule { }
