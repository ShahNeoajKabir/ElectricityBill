import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AddUserRoleComponent } from './add-user-role/add-user-role.component';
import { ListUserRoleComponent } from './list-user-role/list-user-role.component';
import { UserRoleRoutingModule } from './userrole-routing.module';
import { UserRoleService } from '../../Service/UserRole/user-role.service';



@NgModule({
  declarations: [AddUserRoleComponent, ListUserRoleComponent],
  imports: [
    CommonModule,
    UserRoleRoutingModule,
    FormsModule
  ],
  providers:[UserRoleService],
})
export class UserRoleModule { }
