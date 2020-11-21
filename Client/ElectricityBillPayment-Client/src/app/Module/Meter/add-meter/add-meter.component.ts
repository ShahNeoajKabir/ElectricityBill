import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from 'src/app/Common/Enum';
import { Utility } from 'src/app/Common/Utility';
import { MeterTable } from 'src/app/Model/MeterTable';
import { MeterService } from 'src/app/Service/Meter/meter.service';

@Component({
  selector: 'app-add-meter',
  templateUrl: './add-meter.component.html',
  styleUrls: ['./add-meter.component.css']
})
export class AddMeterComponent implements OnInit {
 public objMeter:MeterTable=new MeterTable();

 public updatemeter:MeterTable=new MeterTable();
 public lstStatus:any;


  constructor(
    private meterservice:MeterService,
     private utility:Utility,
     private router:Router,
     private activeroute:ActivatedRoute) { }


  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);

    if (this.activeroute.snapshot.params['id'] !== undefined) {

      this.updatemeter.MeterId = this.activeroute.snapshot.params['id' ];
      this.meterservice.GetById(this.updatemeter).subscribe(( res: any) => {

        this.objMeter = res;
        console.log(this.objMeter);
     });
      console.log(this.activeroute.snapshot.params['id' ] );

    }
  }

  AddMeter(){
    console.log(this.objMeter);
    if (this.objMeter.MeterId > 0 ) {
      this.meterservice.UpdateMeter(this.objMeter).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/Meter/View']);
          console.log(res);
        }
        console.log(res);
      } );
    }
    else {
      this.meterservice.AddMeter(this.objMeter).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/Meter/View']);
          console.log(res);
        }
        console.log(res);
      } );
    }
  }

}
