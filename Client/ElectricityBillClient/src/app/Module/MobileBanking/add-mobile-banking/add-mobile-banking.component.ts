import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MobileBankingType, Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { MobileBanking } from '../../../Model/MobileBanking';
import { MobileBankingService } from '../../../Service/Mobilebanking/mobile-banking.service';
import { NotificationService } from '../../../Service/Notification/notification.service';

@Component({
  selector: 'app-add-mobile-banking',
  templateUrl: './add-mobile-banking.component.html',
  styleUrls: ['./add-mobile-banking.component.css']
})
export class AddMobileBankingComponent implements OnInit {

  public objmobile:MobileBanking=new MobileBanking();
  public lststatus:any;
  public lstmobilebankingtype:any;

  constructor(private mobilebankingservice:MobileBankingService,private utility:Utility,private router:Router, private notificationservice:NotificationService) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
    this.lstmobilebankingtype=this.utility.enumToArray(MobileBankingType);

  }

  AddMobile(){
    console.log(this.objmobile);
    
    
    this.mobilebankingservice.AddMobile(this.objmobile).subscribe(res => {
      
        console.log(res);
        if(res){
          this.notificationservice.successNotification("successful");
        this.router.navigate(['/MobileBanking/View']);

        }
      
    } );
  
}

}

