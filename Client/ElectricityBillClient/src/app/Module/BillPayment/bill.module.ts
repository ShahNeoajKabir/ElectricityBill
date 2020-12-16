import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BillTableService } from '../../Service/BillTable/bill-table.service';
import { BillPaymentComponent } from './bill-payment/bill-payment.component';
import { BillRoutingModule } from './bill-routing.module';



@NgModule({
  declarations: [ BillPaymentComponent],
  imports: [
    CommonModule,
    BillRoutingModule,
    FormsModule
  ],
  providers:[BillTableService],
})
export class BillModule { }
