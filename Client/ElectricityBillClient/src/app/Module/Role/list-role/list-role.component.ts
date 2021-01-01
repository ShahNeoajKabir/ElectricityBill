import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../../Common/Auth/auth.service';
import { Role } from '../../../Model/Role';
import { RoleService } from '../../../Service/Role/role.service';

@Component({
  selector: 'app-list-role',
  templateUrl: './list-role.component.html',
  styleUrls: ['./list-role.component.css']
})
export class ListRoleComponent implements OnInit {
  public lstrole:Role[]=new Array<Role>();
  public search:string="";

  constructor(private roleservice:RoleService,private router:Router,private authService:AuthService) { }

  ngOnInit(): void {
    console.log(this.authService.getUserRole(),this.authService.getLoggedUserId())
    this.roleservice.GetAll().subscribe((res:any)=>{
      this.lstrole=res;
      console.log(this.lstrole);
    },err=>{
      
      this.router.navigate(['/Login']);

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
