import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { SignInComponent } from './sign-in/sign-in.component';


const routes: Routes = [
{ path: 'Login', component: SignInComponent },
{ path: 'ChangePassword', component: ChangePasswordComponent },







];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SigninRoutingModule { }
