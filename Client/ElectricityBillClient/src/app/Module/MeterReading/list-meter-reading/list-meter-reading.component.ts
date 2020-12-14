import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MeterReadingTable } from '../../../Model/MeterReadingTable';
import { MeterReadingService } from '../../../Service/MeterReading/meter-reading.service';

@Component({
  selector: 'app-list-meter-reading',
  templateUrl: './list-meter-reading.component.html',
  styleUrls: ['./list-meter-reading.component.css']
})
export class ListMeterReadingComponent implements OnInit {
  public lstmeterreading:MeterReadingTable[]=new Array<MeterReadingTable>();

  constructor(private meterreadingservice:MeterReadingService, private router:Router) { }

  ngOnInit(): void {
    this.meterreadingservice.GetAll().subscribe((res:any)=>{
      this.lstmeterreading=res;
      console.log(this.lstmeterreading);

    })
  }
  Edit(id:any){
    console.log(id);
  }
}
