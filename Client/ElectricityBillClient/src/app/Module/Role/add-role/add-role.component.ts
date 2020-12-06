import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Role } from '../../../Model/Role';
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
    private ActivateRouter:ActivatedRoute
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
        if (res === 1) {
          this.router.navigate(['/Role/View']);
          console.log(res);
        }
        console.log(res);
      } );
    } else {
      this.roleservice.AddRole(this.objRole).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/Role/View']);
          console.log(res);
        }
        console.log(res);
      } );
    }


  }

}
