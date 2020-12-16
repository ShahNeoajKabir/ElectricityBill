import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MobileBanking } from '../../../Model/MobileBanking';
import { MobileBankingService } from '../../../Service/Mobilebanking/mobile-banking.service';

@Component({
  selector: 'app-list-mobile-banking',
  templateUrl: './list-mobile-banking.component.html',
  styleUrls: ['./list-mobile-banking.component.css']
})
export class ListMobileBankingComponent implements OnInit {

  public lstmobile:MobileBanking[]=new Array<MobileBanking>();

  constructor( private mobilebankingservice:MobileBankingService, private router:Router,private activated:ActivatedRoute) { }

  ngOnInit(): void {

    this.mobilebankingservice.GetAll().subscribe((res:any)=>{
      this.lstmobile=res;
      console.log(this.lstmobile);
    })
  }

  Edit(id:any){
    console.log(id);
  }

}
