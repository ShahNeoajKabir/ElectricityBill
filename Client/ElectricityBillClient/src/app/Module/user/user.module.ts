import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddUserComponent } from './add-user/add-user.component';
import { ListUserComponent } from './list-user/list-user.component';
import { UserRoutingModule } from './user-routing.module';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../Service/User/user.service';




@NgModule({
  declarations: [AddUserComponent, ListUserComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule
  ],
  providers:[UserService],
})
export class UserModule { }
