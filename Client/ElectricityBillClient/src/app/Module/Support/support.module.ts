import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddSupportComponent } from './add-support/add-support.component';
import { ListSupportComponent } from './list-support/list-support.component';
import { SupportRoutingModule } from './support-routing.module';
import { SupportService } from '../../Service/Support/support.service';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';




@NgModule({
  declarations: [AddSupportComponent, ListSupportComponent],
  imports: [
    CommonModule,
    FormsModule,
    SupportRoutingModule,
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
  })
  ],providers:[SupportService],

})
export class SupportModule { }
