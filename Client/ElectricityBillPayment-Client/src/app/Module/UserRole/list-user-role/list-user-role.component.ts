import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserRole } from 'src/app/Model/UserRole';
import { UserRoleService } from 'src/app/Service/UserRole/user-role.service';

@Component({
  selector: 'app-list-user-role',
  templateUrl: './list-user-role.component.html',
  styleUrls: ['./list-user-role.component.css']
})
export class ListUserRoleComponent implements OnInit {
  public lstuserrole:UserRole[]=new Array<UserRole>();
  public search:string="";

  constructor(private userroleservice:UserRoleService,private router:Router) { }

  ngOnInit(): void {
    this.userroleservice.GetAll().subscribe((res:any)=>{
      this.lstuserrole=res;
      console.log(this.lstuserrole);

    })
  }
  Edit(id:any){
    console.log(id);
  }
  Search(){
    this.userroleservice.Search(this.search).subscribe((res:any)=>{
      this.lstuserrole=res;
      console.log(this.lstuserrole);
    })
  }

}
