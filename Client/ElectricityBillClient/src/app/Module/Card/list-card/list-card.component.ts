import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CardInformation } from '../../../Model/CardInformation';
import { CardService } from '../../../Service/Card/card.service';

@Component({
  selector: 'app-list-card',
  templateUrl: './list-card.component.html',
  styleUrls: ['./list-card.component.css']
})
export class ListCardComponent implements OnInit {
  public lstcard:CardInformation[]=new Array<CardInformation>();

  constructor(private cardservice:CardService,private router:Router) { }

  ngOnInit(): void {

    this.cardservice.GetAll().subscribe((res:any)=>{
      this.lstcard=res;
      console.log(this.lstcard);
    })
  }
  Edit(id: any) {

    console.log(id);
  }

}
