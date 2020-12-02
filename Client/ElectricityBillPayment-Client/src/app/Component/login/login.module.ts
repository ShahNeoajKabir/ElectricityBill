import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from 'src/app/Service/User/user.service';
import { LoginComponent } from './login.component';
import { LoginRoutingModule } from './login-routing.module';
import { SecurityService } from 'src/app/Service/Security/security.service';



@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    LoginRoutingModule,
    FormsModule
  ],
  providers:[SecurityService],
})
export class LoginModule { }
