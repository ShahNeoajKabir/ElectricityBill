import { Component, OnInit } from '@angular/core';
import { MeterTable } from 'src/app/Model/MeterTable';
import { MeterService } from 'src/app/Service/Meter/meter.service';

@Component({
  selector: 'app-add-meter',
  templateUrl: './add-meter.component.html',
  styleUrls: ['./add-meter.component.css']
})
export class AddMeterComponent implements OnInit {
 objMeter:MeterTable=new MeterTable();
  constructor(private meterservice:MeterService) { }

  ngOnInit(): void {
  }

  AddMeter(){
    this.meterservice.AddMeter(this.objMeter).subscribe((res:any)=>{
      console.log(res);
    })
  }

}
