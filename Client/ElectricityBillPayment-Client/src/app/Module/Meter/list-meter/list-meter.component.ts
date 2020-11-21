import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MeterTable } from 'src/app/Model/MeterTable';
import { MeterService } from 'src/app/Service/Meter/meter.service';

@Component({
  selector: 'app-list-meter',
  templateUrl: './list-meter.component.html',
  styleUrls: ['./list-meter.component.css']
})
export class ListMeterComponent implements OnInit {

  public lstMeter:MeterTable[]=new Array<MeterTable>();

  constructor(private meterservice:MeterService, private router:Router) { }

  ngOnInit(): void {
    this.meterservice.GetAll().subscribe((res:any)=>{
      this.lstMeter=res;
      console.log(this.lstMeter);
    })
  }

  Edit(id:any){
    console.log(id);


  }

}
