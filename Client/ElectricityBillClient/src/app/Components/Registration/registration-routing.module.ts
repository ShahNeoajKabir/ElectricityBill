import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutModule } from '@coreui/angular/lib/shared/layout/layout.module';
import { CustomerRegistrationComponent } from './customer-registration/customer-registration.component';


const routes: Routes = [
{ path: 'Registration', component: CustomerRegistrationComponent },



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegistrationRoutingModule { }
