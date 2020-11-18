import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/Model/User';
import { UserService } from 'src/app/Service/User/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  objUser:User=new User();
  constructor(
    private userservice:UserService
  ) { }

  ngOnInit(): void {
  }


  save(){
    this.userservice.AddUser(this.objUser).subscribe((res:any)=>{
      console.log(res);
    })

  }

}
