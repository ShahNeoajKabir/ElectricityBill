import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
// import { BrowserModule } from '@angular/platform-browser'
import { CommonModule } from '@angular/common';

import { DashboardComponent } from './dashboard.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import {AgmMap,MapsAPILoader, AgmCoreModule  } from '../../../../node_modules/@agm/core'; 
import { CustomerService } from '../../Service/Customer/customer.service';


@NgModule({
  imports: [
    FormsModule,
    // BrowserModule,
    CommonModule,
    DashboardRoutingModule,
    ChartsModule,
    BsDropdownModule,
    AgmCoreModule.forRoot({  
      apiKey: 'AIzaSyBib2Nuc4iRnft_GXCfAOSkobRbN7u-wJQ'  
    }),
    ButtonsModule.forRoot()
  ],
  declarations: [ DashboardComponent ],
  providers:[CustomerService]
})
export class DashboardModule { }
