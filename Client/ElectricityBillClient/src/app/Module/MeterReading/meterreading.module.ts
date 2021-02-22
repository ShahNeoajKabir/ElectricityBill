import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddMeterReadingComponent } from './add-meter-reading/add-meter-reading.component';
import { ListMeterReadingComponent } from './list-meter-reading/list-meter-reading.component';
import { MeterReadingRoutingModule } from './meterreading-routing.mdule';
import { MeterReadingService } from '../../Service/MeterReading/meter-reading.service';
import { ModalModule } from 'ngx-bootstrap/modal';



@NgModule({
  declarations: [AddMeterReadingComponent, ListMeterReadingComponent],
  imports: [
    CommonModule,
    MeterReadingRoutingModule,
    FormsModule,
    ModalModule.forRoot()
  ],
  providers:[MeterReadingService],
})
export class MeterReadingModule { }
