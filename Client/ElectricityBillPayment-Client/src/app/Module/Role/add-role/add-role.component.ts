import { Component, OnInit } from '@angular/core';
import { Role } from 'src/app/Model/Role';
import { RoleService } from 'src/app/Service/Role/role.service';

@Component({
  selector: 'app-add-role',
  templateUrl: './add-role.component.html',
  styleUrls: ['./add-role.component.css']
})
export class AddRoleComponent implements OnInit {
  objRole:Role=new Role();

  constructor(private roleservice:RoleService) { }

  ngOnInit(): void {
  }

  AddRole(){
    this.roleservice.AddRole(this.objRole).subscribe((res:any)=>{
      console.log(res);
    })
  }

}
