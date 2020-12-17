import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Import Containers
import { DefaultLayoutComponent } from './containers';

import { P404Component } from './views/error/404.component';
import { P500Component } from './views/error/500.component';
import { LoginComponent } from './views/login/login.component';

import { RegisterComponent } from './views/register/register.component';


export const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',


  },

  // {
  //   path: '404',
  //   component: P404Component,
  //   data: {
  //     title: 'Page 404'
  //   }
  // },
  // {
  //   path: '500',
  //   component: P500Component,
  //   data: {
  //     title: 'Page 500'
  //   }
  // },
  // {
  //   path: 'login',
  //   component: LoginComponent,
  //   data: {
  //     title: 'Login Page'
  //   }
  // },
  // {
  //   path: 'register',
  //   component: RegisterComponent,
  //   data: {
  //     title: 'Register Page'
  //   }
  // },
  { path: '', loadChildren: () => import('../app/Components/signin.module').then(m => m.SigninModule) },


  {
    path: '',
    component: DefaultLayoutComponent,
    data: {
      title: 'Home'
    },

    children: [
      { path: 'User', loadChildren: () => import('./Module/user/user.module').then(m => m.UserModule) },
      { path: 'Notice', loadChildren: () => import('./Module/Notice/Notice.modules').then(p=>p.NoticeModule)},
      {path: 'Support', loadChildren:()=> import('./Module/Support/support.module').then(p=>p.SupportModule)},
      {path: 'Meter', loadChildren:()=>import('./Module/Meter/meter.module').then(n=>n.MeterModule)},
      {path: 'Role', loadChildren:()=>import('./Module/Role/role.module').then(n=>n.RoleModule)},
      {path:'AssignMeter' ,loadChildren:()=>import('./Module/MeterAssign/AssignMeter.modules').then(n=>n.AssignMeterModule)},
      {path:'Zone' ,loadChildren:()=>import('./Module/Zone/zone.module').then(n=>n.ZoneModule)},
      {path:'UserRole' ,loadChildren:()=>import('./Module/UserRole/userrole.module').then(n=>n.UserRoleModule)},
      {path:'Customer' ,loadChildren:()=>import('./Module/Customer/customer.module').then(n=>n.CustomerModule)},
      {path:'ZoneAssign' ,loadChildren:()=>import('./Module/ZoneAssign/ZoneAssign.module').then(n=>n.ZoneAssignModule)},
      // {path:'Security' ,loadChildren:()=>import('./Components/signin.module').then(n=>n.SigninModule)},
      {path:'UnitPrice' ,loadChildren:()=>import('./Module/UnitPrice/unitprice.module').then(n=>n.UnitPriceModule)},
      {path:'MeterReading' ,loadChildren:()=>import('./Module/MeterReading/meterreading.module').then(n=>n.MeterReadingModule)},
      {path:'BillTable' ,loadChildren:()=>import('./Module/BillPayment/bill.module').then(n=>n.BillModule)},
      {path:'Card' ,loadChildren:()=>import('./Module/Card/card.module').then(n=>n.CardModule)},
      {path:'MobileBanking' ,loadChildren:()=>import('./Module/MobileBanking/mobilebanking.module').then(n=>n.MobileBankingModule)},









      // {
      //   path: 'base',
      //   loadChildren: () => import('./views/base/base.module').then(m => m.BaseModule)
      // },
      // {
      //   path: 'buttons',
      //   loadChildren: () => import('./views/buttons/buttons.module').then(m => m.ButtonsModule)
      // },
      // {
      //   path: 'charts',
      //   loadChildren: () => import('./views/chartjs/chartjs.module').then(m => m.ChartJSModule)
      // },
      {
        path: 'dashboard',
        loadChildren: () => import('./views/dashboard/dashboard.module').then(m => m.DashboardModule)
      },
      // {
      //   path: 'icons',
      //   loadChildren: () => import('./views/icons/icons.module').then(m => m.IconsModule)
      // },
      // {
      //   path: 'notifications',
      //   loadChildren: () => import('./views/notifications/notifications.module').then(m => m.NotificationsModule)
      // },
      // {
      //   path: 'theme',
      //   loadChildren: () => import('./views/theme/theme.module').then(m => m.ThemeModule)
      // },
      // {
      //   path: 'widgets',
      //   loadChildren: () => import('./views/widgets/widgets.module').then(m => m.WidgetsModule)
      // }
    ]
  },
  // { path: '**', component: P404Component }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
