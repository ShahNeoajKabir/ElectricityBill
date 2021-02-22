import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Utility } from '../../../Common/Utility';
import { CustomerService } from '../../../Service/Customer/customer.service';
import { UserService } from '../../../Service/User/user.service';

@Component({
  selector: 'app-bill-paper-view',
  templateUrl: './bill-paper-view.component.html',
  styleUrls: ['./bill-paper-view.component.css']
})
export class BillPaperViewComponent implements OnInit {
  public BillId:any;
  public objuser:any ;
  public userid:any;
  constructor(private utility:Utility,private router:Router, private activateroute:ActivatedRoute, private customerservice:CustomerService,private userservice:UserService) { }

  ngOnInit(): void {
    this.customerservice.ViewBillPaper().subscribe(( res: any) => {

      this.objuser = res;
      console.log(this.objuser);
   });
    
  }

}
