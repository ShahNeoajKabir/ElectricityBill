import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from 'src/app/Common/Enum';
import { Utility } from 'src/app/Common/Utility';
import { MeterAssign } from 'src/app/Model/MeterAssign';
import { MeterService } from 'src/app/Service/Meter/meter.service';
import { MeterAssignService } from 'src/app/Service/MeterAssign/meter-assign.service';

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
    private meterservice:MeterService
    ) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
    this.meterservice.GetAll().subscribe((res: any) => {
      console.log(res);

      this.lstmetertable = res;
      console.log(this.lstmetertable);

    });
    if (this.activeroute.snapshot.params[ 'id'] !== undefined) {
      this.objedit.MeterAssignId = this.activeroute.snapshot.params[ 'id'];
      this.meterassignservice.GetById(this.objedit).subscribe((res: any) => {
        this.lstmeterassign = res;
        console.log(this.lstmeterassign);
      });
      console.log(this.activeroute.snapshot.params[ 'id']);
    }
  }
  submit() {
    console.log(this.lstmeterassign);
    if ( this.lstmeterassign.MeterAssignId > 0) {
      this.meterassignservice.UpdateAssign(this.lstmeterassign).subscribe(res => {
        if ( res === 1) {
        this.router.navigate(['/AssignMeter/View']);

        console.log(res);

        }
        console.log(res);
      });
    } else {
      this.meterassignservice.AssignMeter(this.lstmeterassign).subscribe(res => {
        this.router.navigate(['/AssignMeter/View']);

        if ( res === 1) {
          console.log(res);
        }
        console.log(res);
      });
    }

}

  

}
