import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

import { NgModule } from '@angular/core';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
};

import { AppComponent } from './app.component';

// Import containers
import { DefaultLayoutComponent } from './containers';

const APP_CONTAINERS = [
  DefaultLayoutComponent
];

import {
  AppAsideModule,
  AppBreadcrumbModule,
  AppHeaderModule,
  AppFooterModule,
  AppSidebarModule,
} from '@coreui/angular';

// Import routing module
import { AppRoutingModule } from './app.routing';

// Import 3rd party components
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ChartsModule } from 'ng2-charts';
import { FormsModule } from '@angular/forms';
import { httpInterceptorProviders } from './Common/interceptor';
import { AuthService } from './Common/Auth/auth.service';

import {AgmMap,MapsAPILoader, AgmCoreModule  } from '../../node_modules/@agm/core';


@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    AppAsideModule,
    AppBreadcrumbModule.forRoot(),
    AppFooterModule,
    AppHeaderModule,
    AppSidebarModule,
    PerfectScrollbarModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    ChartsModule,
    AgmCoreModule.forRoot({  
      apiKey: 'AIzaSyBib2Nuc4iRnft_GXCfAOSkobRbN7u-wJQ'  
    }),
    ToastrModule.forRoot(
  ),
  ],
  declarations: [
    AppComponent,
    APP_CONTAINERS,
    // P404Component,
    // P500Component,
    // LoginComponent,
    // RegisterComponent
  ],
  providers: [HttpClientModule,httpInterceptorProviders,{
    provide: LocationStrategy,
    useClass: HashLocationStrategy,


  },AuthService],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
