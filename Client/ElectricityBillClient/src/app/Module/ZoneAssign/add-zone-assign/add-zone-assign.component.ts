import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { ZoneAssign } from '../../../Model/ZoneAssign';
import { UserService } from '../../../Service/User/user.service';
import { ZoneService } from '../../../Service/Zone/zone.service';
import { ZoneAssignService } from '../../../Service/ZoneAssign/zone-assign.service';

@Component({
  selector: 'app-add-zone-assign',
  templateUrl: './add-zone-assign.component.html',
  styleUrls: ['./add-zone-assign.component.css']
})
export class AddZoneAssignComponent implements OnInit {
  public objzoneassign:ZoneAssign=new ZoneAssign();
  public editzoneassign:ZoneAssign=new ZoneAssign();
  public lststatus:any;
  public lstuser:any;
  public lstzone:any;

  constructor(
    private zoneassignservice:ZoneAssignService,
    private activateroute:ActivatedRoute,
    private router:Router,
    private userservice:UserService,
    private zoneservice:ZoneService,
    private utility:Utility
    ) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
    this.userservice.GetAllMeterReader().subscribe((res:any)=>{
      console.log(res);
      this.lstuser=res;
      console.log(this.lstuser);
    })

    this.zoneservice.GetAll().subscribe((res: any) => {
      console.log(res);

      this.lstzone = res;
      console.log(this.lstzone);

    });

    if (this.activateroute.snapshot.params[ 'id'] !== undefined) {
      this.editzoneassign.ZoneAssignId = this.activateroute.snapshot.params[ 'id'];
      this.zoneassignservice.GetById(this.editzoneassign).subscribe((res: any) => {
        this.objzoneassign = res;
        console.log(this.objzoneassign);
      });
      console.log(this.activateroute.snapshot.params[ 'id']);
    }
  }
  submit() {
    console.log(this.objzoneassign);
    if ( this.objzoneassign.ZoneAssignId > 0) {
      this.zoneassignservice.UpdateZoneAssign(this.objzoneassign).subscribe(res => {
        if ( res === 1) {
        this.router.navigate(['/ZoneAssign/View']);

        console.log(res);

        }
        console.log(res);
      });
    } else {
      this.zoneassignservice.AssignZone(this.objzoneassign).subscribe(res => {
        this.router.navigate(['/ZoneAssign/View']);

        if ( res === 1) {
          console.log(res);
        }
        console.log(res);
      });
    }
  }

}
