import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from 'src/app/Service/User/user.service';
import { AddMeterComponent } from './add-meter/add-meter.component';
import { ListMeterComponent } from './list-meter/list-meter.component';
import { MeterRoutingModule } from './meter-routing.module';
import { MeterService } from 'src/app/Service/Meter/meter.service';



@NgModule({
  declarations: [AddMeterComponent, ListMeterComponent],
  imports: [
    CommonModule,
    MeterRoutingModule,
    FormsModule
  ],
  providers:[MeterService],
})
export class MeterModule { }
