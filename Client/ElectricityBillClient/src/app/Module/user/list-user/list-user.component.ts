import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../../Model/User';
import { UserService } from '../../../Service/User/user.service';
import { navItems } from '../../../_nav';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {
  public lstUser:User[]= new Array<User>();
  public lstuser:User[]= new Array<User>();

  public searchuser:string="";
 

  constructor(private userservice:UserService, private router:Router) { }

  ngOnInit(): void {
    this.userservice.GetAll().subscribe((res:any)=>{
      this.lstUser=res;
      console.log(this.lstUser);
    });
    this.userservice.GetAllMeterReader().subscribe((res:any)=>{
      this.lstuser=res;
      console.log(this.lstuser);
    })
  }
  Edit(id: any) {

    console.log(id);
  }

  searchUsers(){

    this.userservice.SearchUser(this.searchuser).subscribe((res:any)=>{
      this.lstUser=res;
      console.log(this.lstUser);
    })

  }




}
