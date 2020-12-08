import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Zone } from '../../../Model/Zone';
import { ZoneService } from '../../../Service/Zone/zone.service';

@Component({
  selector: 'app-add-zone',
  templateUrl: './add-zone.component.html',
  styleUrls: ['./add-zone.component.css']
})
export class AddZoneComponent implements OnInit {
  public objzone:Zone=new Zone();
  public editZone:Zone=new Zone();
  lststatus:any;

  constructor(
    private zoneservice:ZoneService,
    private utility:Utility,
    private ActivateRouter:ActivatedRoute,
    private router:Router
    ) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);

    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.editZone.ZoneId = this.ActivateRouter.snapshot.params['id' ];
      this.zoneservice.GetById(this.editZone).subscribe(( res: any) => {

        this.objzone = res;
        console.log(this.objzone);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }

  AddZone(){
    console.log(this.objzone);
    if (this.objzone.ZoneId > 0 ) {
      this.zoneservice.UpdateZone(this.objzone).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/Zone/View']);
          console.log(res);
        }
        console.log(res);
      } );
    } else {
      this.zoneservice.AddZone(this.objzone).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/Zone/View']);
          console.log(res);
        }
        console.log(res);
      } );
    }


  }

}
