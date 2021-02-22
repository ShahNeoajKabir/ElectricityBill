import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SecurityService } from '../Service/Security/security.service';
import { SignInComponent } from './sign-in/sign-in.component';
import { SigninRoutingModule } from './sigin-routing.module';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { UserService } from '../Service/User/user.service';



@NgModule({
  declarations: [ SignInComponent, ChangePasswordComponent],
  imports: [
    CommonModule,
    SigninRoutingModule,
    FormsModule
  ],
  providers:[SecurityService,UserService ],
})
export class SigninModule { }
