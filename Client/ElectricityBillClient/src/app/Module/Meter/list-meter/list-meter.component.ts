import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MeterTable } from '../../../Model/MeterTable';
import { MeterService } from '../../../Service/Meter/meter.service';

@Component({
  selector: 'app-list-meter',
  templateUrl: './list-meter.component.html',
  styleUrls: ['./list-meter.component.css']
})
export class ListMeterComponent implements OnInit {

  public lstMeter:MeterTable[]=new Array<MeterTable>();
  public search:string="";

  constructor(private meterservice:MeterService, private router:Router) { }

  ngOnInit(): void {
    this.meterservice.GetAllMeter().subscribe((res:any)=>{
      this.lstMeter=res;
      console.log(this.lstMeter);
    })
  }

  Edit(id:any){
    console.log(id);
  }
  Search(){
    this.meterservice.SearchMeter(this.search).subscribe((res:any)=>{
      this.lstMeter=res;
      console.log(this.lstMeter);
    })
  }

}
