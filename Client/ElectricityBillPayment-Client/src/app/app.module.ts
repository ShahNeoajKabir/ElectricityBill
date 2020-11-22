import { BrowserModule } from '@angular/platform-browser';


import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutComponent } from './Component/layout/layout.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CustomerRegistrationComponent } from './Component/customer-registration/customer-registration.component';
import { LoginComponent } from './Component/login/login.component';
import { ToastrModule } from 'ngx-toastr/toastr/toastr.module';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    CustomerRegistrationComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
  })
  ],
  providers: [HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
