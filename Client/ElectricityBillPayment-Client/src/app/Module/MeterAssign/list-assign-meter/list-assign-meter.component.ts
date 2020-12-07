import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MeterAssign } from 'src/app/Model/MeterAssign';
import { MeterAssignService } from 'src/app/Service/MeterAssign/meter-assign.service';

@Component({
  selector: 'app-list-assign-meter',
  templateUrl: './list-assign-meter.component.html',
  styleUrls: ['./list-assign-meter.component.css']
})
export class ListAssignMeterComponent implements OnInit {

  public objassign:MeterAssign[]=new Array<MeterAssign>();

  constructor(private meterassignservice:MeterAssignService,private router:Router ) { }

  ngOnInit(): void {
    this.meterassignservice.GEtAll().subscribe((res:any)=>{
      this.objassign=res;
      console.log(this.objassign);
    })
  }
  Edit(id:any){
    console.log(id);
  }

}