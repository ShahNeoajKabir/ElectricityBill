import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { CardInformation } from '../../../Model/CardInformation';
import { CardService } from '../../../Service/Card/card.service';
import { NotificationService } from '../../../Service/Notification/notification.service';

@Component({
  selector: 'app-add-card',
  templateUrl: './add-card.component.html',
  styleUrls: ['./add-card.component.css']
})
export class AddCardComponent implements OnInit {
public objcard:CardInformation=new CardInformation();
public editcard:CardInformation=new CardInformation();
public lststatus:any;


  constructor(private cardservice:CardService,private utility:Utility,private router:Router,private ActivateRouter:ActivatedRoute , private notificationservice:NotificationService) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);

    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.editcard.CardInformationId = this.ActivateRouter.snapshot.params['id' ];
      this.cardservice.GetById(this.editcard).subscribe(( res: any) => {

        this.objcard = res;
        console.log(this.objcard);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }

  AddCard(){
    console.log(this.objcard);
    
    
      this.cardservice.AddCard(this.objcard).subscribe(res => {
        
         
          console.log(res);
          if(res){
            this.notificationservice.successNotification();
            this.router.navigate(['/Card/View'])
          }
        
      },er=>{
        this.notificationservice.ErrorNotification();
        this.router.navigate(['/Card/AddCard']);
      });
    
  }
}
