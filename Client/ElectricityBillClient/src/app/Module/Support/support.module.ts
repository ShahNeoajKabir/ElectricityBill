import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddSupportComponent } from './add-support/add-support.component';
import { ListSupportComponent } from './list-support/list-support.component';
import { SupportRoutingModule } from './support-routing.module';
import { SupportService } from '../../Service/Support/support.service';




@NgModule({
  declarations: [AddSupportComponent, ListSupportComponent],
  imports: [
    CommonModule,
    FormsModule,
    SupportRoutingModule
  ],providers:[SupportService],

})
export class SupportModule { }
