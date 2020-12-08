import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from 'src/app/Service/User/user.service';
import { ZoneService } from 'src/app/Service/Zone/zone.service';
import { AddZoneComponent } from './add-zone/add-zone.component';
import { ListZoneComponent } from './list-zone/list-zone.component';
import { ZoneRoutingModule } from './zone-routing.module';



@NgModule({
  declarations: [AddZoneComponent, ListZoneComponent],
  imports: [
    CommonModule,
    ZoneRoutingModule,
    FormsModule
  ],
  providers:[ZoneService],
})
export class ZoneModule { }
