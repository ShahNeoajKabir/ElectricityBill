import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AssignMeterComponent } from './assign-meter/assign-meter.component';
import { ListAssignMeterComponent } from './list-assign-meter/list-assign-meter.component';
import { AssignMeterRoutingModule } from './assignmeter-routing.module';
import { MeterAssignService } from '../../Service/MeterAssign/meter-assign.service';
import { ListMeterAssignforCustomerComponent } from './list-meter-assignfor-customer/list-meter-assignfor-customer.component';
import { ModalModule } from 'ngx-bootstrap/modal';



@NgModule({
  declarations: [AssignMeterComponent, ListAssignMeterComponent,ListMeterAssignforCustomerComponent],
  imports: [
    CommonModule,
    AssignMeterRoutingModule,
    FormsModule,
    ModalModule.forRoot()
  ],
  providers:[MeterAssignService],
})
export class AssignMeterModule { }
