
import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { NotificationService } from '../../../Service/Notification/notification.service';
import { Utility } from '../../../Common/Utility';
import { MeterTable } from '../../../Model/MeterTable';
import { MeterService } from '../../../Service/Meter/meter.service';

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
     private activeroute:ActivatedRoute,
     private notification:NotificationService
     ) { }


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
      this.meterservice.UpdateMeter(this.objMeter).subscribe(res=>{
        console.log(res);
        if(res){
          this.notification.updateNotification();
          this.router.navigate(['/Meter/View']);

        }
      },er=>{
        this.notification.ErrorNotification();
        this.router.navigate(['/Meter/View']);
      });
         
    }
    else {

      this.meterservice.AddMeter(this.objMeter).subscribe(res=>{
        console.log(res);
        if(res){
          this.notification.successNotification();
          this.router.navigate(['/Meter/View']);
        }
      },er=>{
        this.notification.ErrorNotification();
        this.router.navigate(['/Meter/AddMeter']);
      });
       
          
        
      
    }
  }

}
