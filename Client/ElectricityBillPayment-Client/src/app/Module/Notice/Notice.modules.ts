import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddNoticeComponent } from './add-notice/add-notice.component';
import { ListNoticeComponent } from './list-notice/list-notice.component';
import { NoticeRoutingModule } from './notice-routing.module';
import { NoticeService } from 'src/app/Service/Notice/notice.service';



@NgModule({
  declarations: [AddNoticeComponent, ListNoticeComponent],
  imports: [
    CommonModule,
    NoticeRoutingModule,
    FormsModule
  ],
  providers:[NoticeService],
})
export class NoticeModule { }
