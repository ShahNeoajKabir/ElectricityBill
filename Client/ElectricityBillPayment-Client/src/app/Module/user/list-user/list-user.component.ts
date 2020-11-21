import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/Model/User';
import { UserService } from 'src/app/Service/User/user.service';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {
  public lstUser:User[]= new Array<User>();

  constructor(private userservice:UserService, private router:Router) { }

  ngOnInit(): void {
    this.userservice.GetAll().subscribe((res:any)=>{
      this.lstUser=res;
      console.log(this.lstUser);
    })
  }
  Edit(id: any) {

    console.log(id);
  }




}
