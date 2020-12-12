import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UnitPrice } from '../../../Model/UnitPrice';
import { UnitPriceService } from '../../../Service/UnitPrice/unit-price.service';

@Component({
  selector: 'app-list-unit-price',
  templateUrl: './list-unit-price.component.html',
  styleUrls: ['./list-unit-price.component.css']
})
export class ListUnitPriceComponent implements OnInit {
  public lstunitprice:UnitPrice[]=new Array<UnitPrice>();

  constructor(private router:Router,private activatedrouter:ActivatedRoute,private unitpriceservice:UnitPriceService) { }

  ngOnInit(): void {

    this.unitpriceservice.GetAll().subscribe((res:any)=>{
      this.lstunitprice=res;
      console.log(this.lstunitprice);
    })
  }

  Edit(id:any){
    console.log(id);
  }

}
