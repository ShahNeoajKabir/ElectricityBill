import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { MobileBanking } from '../../../Model/MobileBanking';
import { MobileBankingService } from '../../../Service/Mobilebanking/mobile-banking.service';

@Component({
  selector: 'app-add-mobile-banking',
  templateUrl: './add-mobile-banking.component.html',
  styleUrls: ['./add-mobile-banking.component.css']
})
export class AddMobileBankingComponent implements OnInit {

  public objmobile:MobileBanking=new MobileBanking();
  public lststatus:any;

  constructor(private mobilebankingservice:MobileBankingService,private utility:Utility,private router:Router) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
  }

  AddMobile(){
    this.mobilebankingservice.AddMobile(this.objmobile).subscribe(res=>{
      console.log(res);
    })

}
}
