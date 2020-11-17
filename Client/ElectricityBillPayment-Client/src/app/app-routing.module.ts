import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { from } from 'rxjs';
import {LayoutComponent} from './Component/layout/layout.component'


const routes: Routes = [
  {path: '',component: LayoutComponent,
  children:[
    { path: 'user', loadChildren: () => import('./Module/user/user.module').then(m => m.UserModule) },
    { path: 'notice', loadChildren: () => import('./Module/Notice/Notice.modules').then(p=>p.NoticeModule)},
    {path: 'support', loadChildren:()=> import('./Module/Support/support.module').then(p=>p.SupportModule)}
  ]

}
]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
