import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Role } from '../../../Model/Role';
import { NotificationService } from '../../../Service/Notification/notification.service';
import { RoleService } from '../../../Service/Role/role.service';

@Component({
  selector: 'app-add-role',
  templateUrl: './add-role.component.html',
  styleUrls: ['./add-role.component.css']
})
export class AddRoleComponent implements OnInit {
  public objRole:Role=new Role();
  public editrole:Role=new Role();
  lststatus:any;

  constructor(
    private roleservice:RoleService,
    private router:Router,
    private utility:Utility,
    private ActivateRouter:ActivatedRoute,
    private notification:NotificationService
    
    ) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.editrole.RoleId = this.ActivateRouter.snapshot.params['id' ];
      this.roleservice.GetById(this.editrole).subscribe(( res: any) => {

        this.objRole = res;
        console.log(this.objRole);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }


  }

  AddRole(){
    console.log(this.objRole);
    if (this.objRole.RoleId > 0 ) {
      this.roleservice.UpdateRole(this.objRole).subscribe(res => {
        console.log(res);
        if(res){
          this.notification.updateNotification();
          this.router.navigate(['/Role/View']);
        }
      },er=>{
        this.notification.ErrorNotification();
          this.router.navigate(['/Role/AddRole']);
      } );
    } else {
      this.roleservice.AddRole(this.objRole).subscribe(res => {
        
        console.log(res);
        if(res){
          this.notification.successNotification();
          this.router.navigate(['/Role/View']);
        }
      },er=>{
        this.notification.ErrorNotification();
          this.router.navigate(['/Role/AddRole']);
      } );
    }


  }

}
