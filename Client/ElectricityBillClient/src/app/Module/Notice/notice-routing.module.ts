import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddNoticeComponent } from './add-notice/add-notice.component';
import { ListNoticeComponent } from './list-notice/list-notice.component';

const route: Routes =[
  { path: 'AddNotice', component: AddNoticeComponent},
  {path: 'View', component:ListNoticeComponent},
  {path:":id/edit",component:AddNoticeComponent}
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(route)],


  exports:[RouterModule]
})
export class NoticeRoutingModule { }
