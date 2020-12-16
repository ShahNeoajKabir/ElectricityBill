import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MobileBankingService } from '../../Service/Mobilebanking/mobile-banking.service';
import { AddMobileBankingComponent } from './add-mobile-banking/add-mobile-banking.component';
import { ListMobileBankingComponent } from './list-mobile-banking/list-mobile-banking.component';
import { MobileBankingRoutingModule } from './mobilebanking-routing.module';



@NgModule({
  declarations: [AddMobileBankingComponent, ListMobileBankingComponent],
  imports: [
    CommonModule,
    MobileBankingRoutingModule,
    FormsModule
  ],
  providers:[MobileBankingService],
})
export class MobileBankingModule { }
