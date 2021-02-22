import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AddZoneComponent } from './add-zone/add-zone.component';
import { ListZoneComponent } from './list-zone/list-zone.component';
import { ZoneRoutingModule } from './zone-routing.module';
import { ZoneService } from '../../Service/Zone/zone.service';
import { ModalModule } from 'ngx-bootstrap/modal';



@NgModule({
  declarations: [AddZoneComponent, ListZoneComponent],
  imports: [
    CommonModule,
    ZoneRoutingModule,
    FormsModule,
    ModalModule.forRoot()
  ],
  providers:[ZoneService],
})
export class ZoneModule { }
