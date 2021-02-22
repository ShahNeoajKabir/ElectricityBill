import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { MeterAssign } from '../../../Model/MeterAssign';
import { CustomerService } from '../../../Service/Customer/customer.service';
import { MeterService } from '../../../Service/Meter/meter.service';
import { MeterAssignService } from '../../../Service/MeterAssign/meter-assign.service';
import { NotificationService } from '../../../Service/Notification/notification.service';

@Component({
  selector: 'app-assign-meter',
  templateUrl: './assign-meter.component.html',
  styleUrls: ['./assign-meter.component.css']
})
export class AssignMeterComponent implements OnInit {
  public lstmeterassign:MeterAssign=new MeterAssign();
  public lststatus:any;
  public objedit:MeterAssign=new MeterAssign();
  public lstmetertable:any;
  public lstcustomer:any;


  constructor(
    private meterassignservice:MeterAssignService,
    private router:Router,
    private activeroute:ActivatedRoute,
    private utility:Utility,
    private meterservice:MeterService,
    private customerservice:CustomerService,
    private notification:NotificationService
    ) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
    this.meterservice.GetAll().subscribe((res: any) => {

      this.lstmetertable = res;

    });
    this.customerservice.GetAllPendingCustomer().subscribe((res: any) => {

      this.lstcustomer = res;

    });
    if (this.activeroute.snapshot.params[ 'id'] !== undefined) {
      this.lstmeterassign.CustomerId = this.activeroute.snapshot.params[ 'id'];
      console.log(this.activeroute.snapshot.params[ 'id']);
    }

  
  }
  submit() {
    if (this.lstmeterassign.MeterAssignId > 0 ) {
      this.meterassignservice.UpdateAssign(this.lstmeterassign).subscribe(res => {
        this.notification.updateNotification();
          this.router.navigate(['/AssignMeter/View']);
       
          
         
       
      },er=>{
        this.notification.ErrorNotification();
        this.router.navigate(['/AssignMeter/View'])
      } );
    }
    else {
      this.meterassignservice.AssignMeter(this.lstmeterassign).subscribe(res => {
        this.notification.successNotification();
        this.router.navigate(['/AssignMeter/View']);
        
        
      }, er=>{
        this.router.navigate(['/AssignMeter/AddAssignMeter']);
        this.notification.ErrorNotification();
      });
    }
  }

}

