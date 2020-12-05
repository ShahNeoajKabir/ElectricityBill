import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { from } from 'rxjs';
import { CustomerRegistrationComponent } from './Component/customer-registration/customer-registration.component';
import {LayoutComponent} from './Component/layout/layout.component'
import { LoginComponent } from './Component/login/login.component';


const routes: Routes = [
  {path:'Login' , component:LoginComponent},
  {path:'Registration' , component:CustomerRegistrationComponent},




  {path: '',component: LayoutComponent,
  children:[
    { path: 'User', loadChildren: () => import('./Module/user/user.module').then(m => m.UserModule) },
    { path: 'Notice', loadChildren: () => import('./Module/Notice/Notice.modules').then(p=>p.NoticeModule)},
    {path: 'Support', loadChildren:()=> import('./Module/Support/support.module').then(p=>p.SupportModule)},
    {path: 'Meter', loadChildren:()=>import('./Module/Meter/meter.module').then(n=>n.MeterModule)},
    {path: 'Role', loadChildren:()=>import('./Module/Role/role.module').then(n=>n.RoleModule)},
    {path:'AssignMeter' ,loadChildren:()=>import('./Module/MeterAssign/AssignMeter.modules').then(n=>n.AssignMeterModule)},
    {path:'Zone' ,loadChildren:()=>import('./Module/Zone/zone.module').then(n=>n.ZoneModule)},
    {path:'UserRole' ,loadChildren:()=>import('./Module/UserRole/userrole.module').then(n=>n.UserRoleModule)}
  ]

}
]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
