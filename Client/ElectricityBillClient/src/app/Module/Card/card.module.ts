import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NoticeService } from '../../Service/Notice/notice.service';
import { AddCardComponent } from './add-card/add-card.component';
import { ListCardComponent } from './list-card/list-card.component';
import { CardService } from '../../Service/Card/card.service';
import { CardRoutingModule } from './card-routing.module';
import { ModalModule } from 'ngx-bootstrap/modal';



@NgModule({
  declarations: [AddCardComponent, ListCardComponent],
  imports: [
    CommonModule,
    CardRoutingModule,
    FormsModule,
    ModalModule.forRoot()
  ],
  providers:[CardService],
})
export class CardModule { }
