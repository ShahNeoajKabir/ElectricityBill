import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { CustomerType, Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { UnitPrice } from '../../../Model/UnitPrice';
import { NotificationService } from '../../../Service/Notification/notification.service';
import { UnitPriceService } from '../../../Service/UnitPrice/unit-price.service';

@Component({
  selector: 'app-add-unit-price',
  templateUrl: './add-unit-price.component.html',
  styleUrls: ['./add-unit-price.component.css']
})
export class AddUnitPriceComponent implements OnInit {
  public objunitprice:UnitPrice=new UnitPrice();
  public editunitprice:UnitPrice=new UnitPrice();
  public lststatus:any;
  public lstcustomertype:any;

  constructor(private unitpriceservice:UnitPriceService,private activatedroute:ActivatedRoute,private router:Router,private unitility:Utility, private notification:NotificationService) { }

  ngOnInit(): void {
    this.lstcustomertype=this.unitility.enumToArray(CustomerType);
    this.lststatus=this.unitility.enumToArray(Status);

    if (this.activatedroute.snapshot.params['id'] !== undefined) {

      this.editunitprice.UnitPriceId = this.activatedroute.snapshot.params['id' ];
      this.unitpriceservice.GetById(this.editunitprice).subscribe(( res: any) => {

        this.objunitprice = res;
        console.log(this.objunitprice);
     });
      console.log(this.activatedroute.snapshot.params['id' ] );

    }

  }

  AddUnitPrice(){
    console.log(this.objunitprice);
    if (this.objunitprice.UnitPriceId > 0 ) {
      this.unitpriceservice.UpdateUnitPrice(this.objunitprice).subscribe(res => {
        
          
          console.log(res);
          if(res){
            
            this.router.navigate(['UnitPrice/View']);
            this.notification.updateNotification();
          }
        
      },er=>{
        this.notification.ErrorNotification();
        this.router.navigate(['AddUnitPrice']);
      } );
    } else {
      this.unitpriceservice.AddUnitPrice(this.objunitprice).subscribe(res => {
        
          
          console.log(res);
          if(res){
            this.notification.successNotification();
            this.router.navigate(['UnitePrice/View']);
          }
        
      },er=>{
        this.notification.ErrorNotification();
        this.router.navigate(['UnitePrice/AddUnitPrice']);
      } );
    }


  }

}
