import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddZoneAssignComponent } from './add-zone-assign/add-zone-assign.component';
import { ListZoneAssignComponent } from './list-zone-assign/list-zone-assign.component';
import { ZoneAssignService } from '../../Service/ZoneAssign/zone-assign.service';
import { ZoneAssignRoutingModule } from './ZoneAssign-routing.module';



@NgModule({
  declarations: [AddZoneAssignComponent, ListZoneAssignComponent],
  imports: [
    CommonModule,
    ZoneAssignRoutingModule,
    FormsModule
  ],
  providers:[ZoneAssignService],
})
export class ZoneAssignModule { }
