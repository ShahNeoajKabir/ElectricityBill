import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AssignMeterComponent } from './assign-meter/assign-meter.component';
import { ListAssignMeterComponent } from './list-assign-meter/list-assign-meter.component';
import { AssignMeterRoutingModule } from './assignmeter-routing.module';
import { MeterAssignService } from '../../Service/MeterAssign/meter-assign.service';



@NgModule({
  declarations: [AssignMeterComponent, ListAssignMeterComponent],
  imports: [
    CommonModule,
    AssignMeterRoutingModule,
    FormsModule
  ],
  providers:[MeterAssignService],
})
export class AssignMeterModule { }
