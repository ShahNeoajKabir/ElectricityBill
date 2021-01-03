import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Month, Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { VMAddMeterReading } from '../../../Model/VMAddMeterReading';
import { MeterReadingService } from '../../../Service/MeterReading/meter-reading.service';

@Component({
  selector: 'app-add-meter-reading',
  templateUrl: './add-meter-reading.component.html',
  styleUrls: ['./add-meter-reading.component.css']
})
export class AddMeterReadingComponent implements OnInit {
  public vmaddmeter:VMAddMeterReading=new VMAddMeterReading();
  public lststatus:any;
  public lstmeter:any;
  public lstmonth:any;
  constructor(
    private meterreadingservice:MeterReadingService,
    private router:Router,
    private activatedroute:ActivatedRoute,
    private utility:Utility,
  ) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
    this.lstmonth=this.utility.enumToArray(Month);

  }

  Submit() {
    this.meterreadingservice.AddMeterReading(this.vmaddmeter).subscribe(res=>{
      this.router.navigate(['/MeterReading/View'])
      console.log(res);
    })


    // console.log(this.objmeterreading);
    // if ( this.objmeterreading.MeterReadingId > 0) {
    //   this.meterreadingservice.UpdateMeterReading(this.objmeterreading).subscribe(res => {
    //     if ( res === 1) {
    //     this.router.navigate(['/MeterReading/View']);

    //     console.log(res);

    //     }
    //     console.log(res);
    //   });
    // } else {
    //   this.meterreadingservice.AddMeterReading(this.objmeterreading).subscribe(res => {
    //     this.router.navigate(['/MeterReading/View']);

    //     if ( res === 1) {
    //       console.log(res);
    //     }
    //     console.log(res);
    //   });
    // }
  }

}
