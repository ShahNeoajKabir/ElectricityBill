import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NoticeService } from 'src/app/Service/Notice/notice.service';
import { AssignMeterComponent } from './assign-meter/assign-meter.component';
import { ListAssignMeterComponent } from './list-assign-meter/list-assign-meter.component';
import { AssignMeterRoutingModule } from './assignmeter-routing.module';



@NgModule({
  declarations: [AssignMeterComponent, ListAssignMeterComponent],
  imports: [
    CommonModule,
    AssignMeterRoutingModule,
    FormsModule
  ],
  providers:[NoticeService],
})
export class AssignMeterModule { }
