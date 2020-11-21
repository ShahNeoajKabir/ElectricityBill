import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Gender, Status, UserType } from 'src/app/Common/Enum';
import { Utility } from 'src/app/Common/Utility';
import { User } from 'src/app/Model/User';
import { UserService } from 'src/app/Service/User/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

 public objUser:User=new User();
  public lstStatus:any ;
  public lstGender:any;
  public lstType:any;
  constructor(
    private userservice:UserService,
    private router: Router,
    private ActivateRouter: ActivatedRoute,
    private utility:Utility
  ) { }

  ngOnInit(): void {
    this.lstStatus = this.utility.enumToArray(Status);
    this.lstGender = this.utility.enumToArray(Gender);
    this.lstType=this.utility.enumToArray(UserType);

  }


  AddUser(){
    console.log(this.objUser);
    this.userservice.AddUser(this.objUser).subscribe(res => {
      if (res === 1) {
        this.router.navigate(['/User/View']);
        console.log(res);
      }
      console.log(res);
    } );

  }

}
