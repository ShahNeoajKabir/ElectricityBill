import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BillTable } from '../../../Model/BillTable';
import { BillTableService } from '../../../Service/BillTable/bill-table.service';

@Component({
  selector: 'app-bill-histrory',
  templateUrl: './bill-histrory.component.html',
  styleUrls: ['./bill-histrory.component.css']
})
export class BillHistroryComponent implements OnInit {
  public lstbill:BillTable[]=new Array<BillTable>();
  constructor(private billservice:BillTableService,private activatedroute:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.billservice.GetAll().subscribe((res:any)=>{
      this.lstbill=res;
      console.log(this.lstbill);
    });
  }

}
