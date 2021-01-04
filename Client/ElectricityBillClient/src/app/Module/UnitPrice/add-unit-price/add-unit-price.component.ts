import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerType, Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { UnitPrice } from '../../../Model/UnitPrice';
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

  constructor(private unitpriceservice:UnitPriceService,private activatedroute:ActivatedRoute,private router:Router,private unitility:Utility) { }

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
        
          this.router.navigate(['/UnitPrice/View']);
          console.log(res);
        
      } );
    } else {
      this.unitpriceservice.AddUnitPrice(this.objunitprice).subscribe(res => {
        
          this.router.navigate(['/UnitPrice/View']);
          console.log(res);
        
      } );
    }


  }

}
