import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Utility } from '../../../Common/Utility';
import { VMProfile } from '../../../Model/VMProfile';
import { CustomerService } from '../../../Service/Customer/customer.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  public UserId:any;
  public vmpayment:VMProfile=new VMProfile();

  constructor(private utility:Utility,private router:Router, private activateroute:ActivatedRoute, private customerservice:CustomerService) { }

  ngOnInit(): void {
    

    if (this.activateroute.snapshot.params[ 'id'] !== undefined) {
      this.UserId = this.activateroute.snapshot.params[ 'id'];
      this.customerservice.ViewProfile(this.UserId).subscribe((res: any) => {
        this.vmpayment = res;
        console.log(this.vmpayment);
      });
      console.log(this.activateroute.snapshot.params[ 'id']);
    }
  }

}
