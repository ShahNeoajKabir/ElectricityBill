import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Utility } from '../../../Common/Utility';
import { User } from '../../../Model/User';
import { VMProfile } from '../../../Model/VMProfile';
import { CustomerService } from '../../../Service/Customer/customer.service';
import { UserService } from '../../../Service/User/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  public objuser:User =new User();
  public userid:any;

  constructor(private utility:Utility,private router:Router, private activeroute:ActivatedRoute, private customerservice:CustomerService,private userservice:UserService) { }

  ngOnInit(): void {
    if (this.activeroute.snapshot.params['id'] !== undefined) {

      this.objuser.UserId = this.activeroute.snapshot.params['id' ];
      this.userservice.GetById(this.objuser).subscribe(( res: any) => {

        this.objuser = res;
        console.log(this.objuser);
     });
      console.log(this.activeroute.snapshot.params['id' ] );

    }
    

    
  }

}
