import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddUserComponent } from './add-user/add-user.component';
import { ListUserComponent } from './list-user/list-user.component';
import { UserRoutingModule } from './user-routing.module';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../Service/User/user.service';
import { ListMeterReaderComponent } from './list-meter-reader/list-meter-reader.component';
import { ModalModule } from 'ngx-bootstrap/modal';




@NgModule({
  declarations: [AddUserComponent, ListUserComponent, ListMeterReaderComponent, ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    ModalModule.forRoot()
  ],
  providers:[UserService],
})
export class UserModule { }
