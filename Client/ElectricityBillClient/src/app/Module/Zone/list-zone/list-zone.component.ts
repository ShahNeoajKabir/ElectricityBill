import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Zone } from '../../../Model/Zone';
import { ZoneService } from '../../../Service/Zone/zone.service';


@Component({
  selector: 'app-list-zone',
  templateUrl: './list-zone.component.html',
  styleUrls: ['./list-zone.component.css']
})
export class ListZoneComponent implements OnInit {
  public lstzone:Zone[]=new Array<Zone>();
  public search:string="";

  constructor(
    private zoneservice:ZoneService,
    private activeroute:ActivatedRoute,
    private router:Router
  ) { }

  ngOnInit(): void {
    this.zoneservice.GetAll().subscribe((res:any)=>{
      this.lstzone=res;
      console.log(this.lstzone);

    })

  }
  Edit(id:any){
    console.log(id);
  }
  Search(){
    this.zoneservice.Search(this.search).subscribe((res:any)=>{
      this.lstzone=res;
      console.log(this.lstzone);
    })
  }

}
