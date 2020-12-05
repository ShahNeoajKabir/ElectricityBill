import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from 'src/app/Common/Enum';
import { Utility } from 'src/app/Common/Utility';
import { UserRole } from 'src/app/Model/UserRole';
import { RoleService } from 'src/app/Service/Role/role.service';
import { UserService } from 'src/app/Service/User/user.service';
import { UserRoleService } from 'src/app/Service/UserRole/user-role.service';

@Component({
  selector: 'app-add-user-role',
  templateUrl: './add-user-role.component.html',
  styleUrls: ['./add-user-role.component.css']
})
export class AddUserRoleComponent implements OnInit {
  public objuserrole:UserRole=new UserRole();
  public edituserrole:UserRole=new UserRole();
  public lststatus:any;
  public lstrole:any;
  public lstuser:any;

  constructor(
    private userroleservice:UserRoleService,
    private router:Router,
    private activatedroute:ActivatedRoute,
    private utility:Utility,
    private userservice:UserService,
    private roleservice:RoleService
  ) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
    this.userservice.GetAll().subscribe((res: any) => {
      console.log(res);

      this.lstuser = res;
      console.log(this.lstuser);

    });

    this.roleservice.GetAll().subscribe((res: any) => {
      console.log(res);

      this.lstrole = res;
      console.log(this.lstrole);

    });

    if (this.activatedroute.snapshot.params[ 'id'] !== undefined) {
      this.edituserrole.UserRoleId = this.activatedroute.snapshot.params[ 'id'];
      this.userroleservice.GetById(this.edituserrole).subscribe((res: any) => {
        this.objuserrole = res;
        console.log(this.objuserrole);
      });
      console.log(this.activatedroute.snapshot.params[ 'id']);
    }

  }

  submit() {
    console.log(this.objuserrole);
    if ( this.objuserrole.UserRoleId > 0) {
      this.userroleservice.UpdateUserRole(this.objuserrole).subscribe(res => {
        if ( res === 1) {
        this.router.navigate(['/UserRole/View']);

        console.log(res);

        }
        console.log(res);
      });
    } else {
      this.userroleservice.AddUserRole(this.objuserrole).subscribe(res => {
        this.router.navigate(['/UserRole/View']);

        if ( res === 1) {
          console.log(res);
        }
        console.log(res);
      });
    }
  }

}
