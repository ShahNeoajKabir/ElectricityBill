import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SecurityService } from '../Service/Security/security.service';
import { SignInComponent } from './sign-in/sign-in.component';
import { SigninRoutingModule } from './sigin-routing.module';



@NgModule({
  declarations: [ SignInComponent],
  imports: [
    CommonModule,
    SigninRoutingModule,
    FormsModule
  ],
  providers:[SecurityService ],
})
export class SigninModule { }
