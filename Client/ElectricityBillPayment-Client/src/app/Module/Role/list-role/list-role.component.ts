import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Role } from 'src/app/Model/Role';
import { RoleService } from 'src/app/Service/Role/role.service';

@Component({
  selector: 'app-list-role',
  templateUrl: './list-role.component.html',
  styleUrls: ['./list-role.component.css']
})
export class ListRoleComponent implements OnInit {
  public lstrole:Role[]=new Array<Role>();
  public search:string="";

  constructor(private roleservice:RoleService,private router:Router) { }

  ngOnInit(): void {
    this.roleservice.GetAll().subscribe((res:any)=>{
      this.lstrole=res;
      console.log(this.lstrole);
    })
  }
  Edit(id:any){
    console.log(id);
  }
  Search(){
    this.roleservice.Search(this.search).subscribe((res:any)=>{
      this.lstrole=res;
      console.log(this.lstrole);
    })
  }

}
