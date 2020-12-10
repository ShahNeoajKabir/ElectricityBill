import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../../Model/User';
import { UserService } from '../../../Service/User/user.service';

@Component({
  selector: 'app-list-meter-reader',
  templateUrl: './list-meter-reader.component.html',
  styleUrls: ['./list-meter-reader.component.css']
})
export class ListMeterReaderComponent implements OnInit {
  // public lstUser:User[]=new Array<User>();

  constructor(private userservice:UserService,private router:Router,private activerouter:ActivatedRoute) { }

  ngOnInit(): void {
    // this.userservice.GetAllMeterReader().subscribe((res:any)=>{
    //   this.lstUser=res;
    //   console.log(this.lstUser);
    // })
  }
  // Edit(id: any) {

  //   console.log(id);
  // }

}
