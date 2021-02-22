import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddMeterComponent } from './add-meter/add-meter.component';
import { ListMeterComponent } from './list-meter/list-meter.component';
import { MeterRoutingModule } from './meter-routing.module';
import { MeterService } from '../../Service/Meter/meter.service';
import { ModalModule } from 'ngx-bootstrap/modal';




@NgModule({
  declarations: [AddMeterComponent, ListMeterComponent],
  imports: [
    CommonModule,
    MeterRoutingModule,
    FormsModule,
    ModalModule.forRoot()
  ],
  providers:[MeterService],
})
export class MeterModule { }
