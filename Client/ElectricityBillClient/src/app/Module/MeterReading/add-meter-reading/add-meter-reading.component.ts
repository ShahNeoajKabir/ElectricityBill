import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Month, Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { MeterReadingTable } from '../../../Model/MeterReadingTable';
import { CustomerService } from '../../../Service/Customer/customer.service';
import { MeterService } from '../../../Service/Meter/meter.service';
import { MeterAssignService } from '../../../Service/MeterAssign/meter-assign.service';
import { MeterReadingService } from '../../../Service/MeterReading/meter-reading.service';

@Component({
  selector: 'app-add-meter-reading',
  templateUrl: './add-meter-reading.component.html',
  styleUrls: ['./add-meter-reading.component.css']
})
export class AddMeterReadingComponent implements OnInit {

  public objmeterreading:MeterReadingTable=new MeterReadingTable();
  public editmeterreading:MeterReadingTable=new MeterReadingTable();
  public lststatus:any;
  public lstmeterassign:any;
  public lstcustomer:any;
  public lstmeter:any;
  public lstmonth:any;
  constructor(
    private meterreadingservice:MeterReadingService,
    private router:Router,
    private activatedroute:ActivatedRoute,
    private utility:Utility,
    private meterassignservice:MeterAssignService,
    private customerservice:CustomerService,
    private meterservice:MeterService
  ) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
    this.lstmonth=this.utility.enumToArray(Month);

    this.meterassignservice.GEtAll().subscribe((res: any) => {
      console.log(res);

      this.lstmeterassign = res;
      console.log(this.lstmeterassign);

    });
    this.customerservice.GetAll().subscribe((res: any) => {
      console.log(res);

      this.lstcustomer = res;
      console.log(this.lstcustomer);

    });

    this.meterservice.GetAllMeter().subscribe((res: any) => {
      console.log(res);

      this.lstmeter = res;
      console.log(this.lstmeter);

    });

    if (this.activatedroute.snapshot.params[ 'id'] !== undefined) {
      this.editmeterreading.MeterReadingId = this.activatedroute.snapshot.params[ 'id'];
      this.meterreadingservice.GetById(this.editmeterreading).subscribe((res: any) => {
        this.objmeterreading = res;
        console.log(this.objmeterreading);
      });
      console.log(this.activatedroute.snapshot.params[ 'id']);
    }

  }

  submit() {
    console.log(this.objmeterreading);
    if ( this.objmeterreading.MeterReadingId > 0) {
      this.meterreadingservice.UpdateMeterReading(this.objmeterreading).subscribe(res => {
        if ( res === 1) {
        this.router.navigate(['/MeterReading/View']);

        console.log(res);

        }
        console.log(res);
      });
    } else {
      this.meterreadingservice.AddMeterReading(this.objmeterreading).subscribe(res => {
        this.router.navigate(['/MeterReading/View']);

        if ( res === 1) {
          console.log(res);
        }
        console.log(res);
      });
    }
  }

}
