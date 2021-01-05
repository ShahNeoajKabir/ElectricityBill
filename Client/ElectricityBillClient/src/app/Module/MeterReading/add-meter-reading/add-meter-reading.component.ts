import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Month, Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { VMAddMeterReading } from '../../../Model/VMAddMeterReading';
import { MeterReadingService } from '../../../Service/MeterReading/meter-reading.service';
import { NotificationService } from '../../../Service/Notification/notification.service';

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
    private notificationservice:NotificationService
  ) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
    this.lstmonth=this.utility.enumToArray(Month);

  }

  Submit() {
    this.meterreadingservice.AddMeterReading(this.vmaddmeter).subscribe(res=>{
      
      console.log(res);
      if(res){
        this.notificationservice.successNotification("Bill Added Successfull");
        this.router.navigate(['/MeterReading/View']);

      }
    },er=>{
      this.notificationservice.ErrorNotification("Invalide Request, Please Try again");
      this.router.navigate(['/MeterReading/AddMeterReading']);
    })


    
  }

}
