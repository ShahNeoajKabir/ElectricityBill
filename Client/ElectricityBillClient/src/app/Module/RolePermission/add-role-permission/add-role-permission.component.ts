import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RolePermission } from '../../../Model/RolePermission';
import {URL} from '../../../Model/URL'
import { RoleService } from '../../../Service/Role/role.service';
import { RolePermissionService } from '../../../Service/RolePermission/role-permission.service';

@Component({
  selector: 'app-add-role-permission',
  templateUrl: './add-role-permission.component.html',
  styleUrls: ['./add-role-permission.component.css']
})
export class AddRolePermissionComponent implements OnInit {
  public lsturl:URL[]=new Array<URL>();
  public objrolepermision:RolePermission=new RolePermission();
  public lstrole:any;

  constructor(private rolepermissionservice:RolePermissionService,private router:Router,private activaterouter:ActivatedRoute,private roleservice:RoleService) { }

  ngOnInit(): void {

    this.rolepermissionservice.GetAll().subscribe((res:any)=>{
      this.lsturl=res;
      console.log(this.lsturl);
    });

    this.roleservice.GetAll().subscribe((res: any) => {
      console.log(res);

      this.lstrole = res;
      console.log(this.lstrole);

    });
  }

  GetUrlByRoleId(RoleId:any){
    console.log(RoleId);

  }

}
