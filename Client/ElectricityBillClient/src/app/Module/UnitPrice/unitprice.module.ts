import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';;
import { FormsModule } from '@angular/forms';
import { AddUnitPriceComponent } from './add-unit-price/add-unit-price.component';
import { ListUnitPriceComponent } from './list-unit-price/list-unit-price.component';
import { UnitPriceService } from '../../Service/UnitPrice/unit-price.service';
import { UnitPriceRoutingModule } from './unitprice-routing.module';




@NgModule({
  declarations: [AddUnitPriceComponent, ListUnitPriceComponent],
  imports: [
    CommonModule,
    UnitPriceRoutingModule,
    FormsModule
  ],
  providers:[UnitPriceService],
})
export class UnitPriceModule { }
