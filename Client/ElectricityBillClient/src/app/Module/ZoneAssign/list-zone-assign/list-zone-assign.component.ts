import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ZoneAssign } from '../../../Model/ZoneAssign';
import { ZoneAssignService } from '../../../Service/ZoneAssign/zone-assign.service';

@Component({
  selector: 'app-list-zone-assign',
  templateUrl: './list-zone-assign.component.html',
  styleUrls: ['./list-zone-assign.component.css']
})
export class ListZoneAssignComponent implements OnInit {
  public lstzoneassign:ZoneAssign[]=new Array<ZoneAssign>();
  public search:string;

  constructor(private zoneassignservice:ZoneAssignService,private router:Router) { }

  ngOnInit(): void {
    this.zoneassignservice.GetAll().subscribe((res:any)=>{
      this.lstzoneassign=res;
      console.log(this.lstzoneassign);

    })
  }

  Edit(id:any){
    console.log(id);

  }

  Search(){
    this.zoneassignservice.Search(this.search).subscribe((res:any)=>{
      this.lstzoneassign=res;
      console.log(this.lstzoneassign);
    })

  }

}
