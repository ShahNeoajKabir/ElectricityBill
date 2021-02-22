import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Zone } from '../../../Model/Zone';
import { NotificationService } from '../../../Service/Notification/notification.service';
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
    private router:Router,
    private notification:NotificationService
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
        
        console.log(res);
        if(res){
          this.notification.updateNotification();
          this.router.navigate(['/Zone/View']);
        }
        
      },er=>{
        this.notification.ErrorNotification();
        this.router.navigate(['/Zone/AddZone']);
      } );
    } else {
      this.zoneservice.AddZone(this.objzone).subscribe(res => {
       
          
          console.log(res);
          if(res){
            this.notification.successNotification();
            this.router.navigate(['/Zone/View']);
          }
        
      },er=>{
        this.notification.ErrorNotification();
        this.router.navigate(['/Zone/AddZone']);
      } );
    }


  }

}
