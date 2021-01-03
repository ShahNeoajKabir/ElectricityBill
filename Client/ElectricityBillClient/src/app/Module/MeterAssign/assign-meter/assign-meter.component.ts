import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { MeterAssign } from '../../../Model/MeterAssign';
import { CustomerService } from '../../../Service/Customer/customer.service';
import { MeterService } from '../../../Service/Meter/meter.service';
import { MeterAssignService } from '../../../Service/MeterAssign/meter-assign.service';

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
    private customerservice:CustomerService
    ) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
    this.meterservice.GetAll().subscribe((res: any) => {
      console.log(res);

      this.lstmetertable = res;
      console.log(this.lstmetertable);

    });
    this.customerservice.GetAllPendingCustomer().subscribe((res: any) => {
      console.log(res);

      this.lstcustomer = res;
      console.log(this.lstcustomer);

    });
    if (this.activeroute.snapshot.params[ 'id'] !== undefined) {
      this.lstmeterassign.CustomerId = this.activeroute.snapshot.params[ 'id'];
      console.log(this.activeroute.snapshot.params[ 'id']);
    }

  
  }
  submit() {
    console.log(this.lstmeterassign);
    if (this.lstmeterassign.MeterAssignId > 0 ) {
      this.meterassignservice.UpdateAssign(this.lstmeterassign).subscribe(res => {
        
          this.router.navigate(['/AssignMeter/View']);
          console.log(res);
       
      } );
    }
    else {
      this.meterassignservice.AssignMeter(this.lstmeterassign).subscribe(res => {
        
          this.router.navigate(['/AssignMeter/View']);
          console.log(res);
        
      } );
    }
  }

}

