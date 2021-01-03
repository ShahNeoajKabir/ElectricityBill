import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MeterAssign } from '../../../Model/MeterAssign';
import { MeterAssignService } from '../../../Service/MeterAssign/meter-assign.service';

@Component({
  selector: 'app-list-meter-assignfor-customer',
  templateUrl: './list-meter-assignfor-customer.component.html',
  styleUrls: ['./list-meter-assignfor-customer.component.css']
})
export class ListMeterAssignforCustomerComponent implements OnInit {

  public objassign:MeterAssign[]=new Array<MeterAssign>();



  public search:string="";

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
  Search(){
    this.meterassignservice.Search(this.search).subscribe((res:any)=>{
      this.objassign=res;
      console.log(this.objassign);
    })
  }
}
