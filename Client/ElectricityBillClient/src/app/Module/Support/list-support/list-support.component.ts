import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Support } from '../../../Model/Support';
import { SupportService } from '../../../Service/Support/support.service';

@Component({
  selector: 'app-list-support',
  templateUrl: './list-support.component.html',
  styleUrls: ['./list-support.component.css']
})
export class ListSupportComponent implements OnInit {

  public objSupport:Support= new Support();
  public lstSupport:Support[]=new Array<Support>();
  public lststatus:any;

  public editsupport:Support=new Support();

  addmodal

  constructor(
    private supportservice:SupportService,
    private router:Router,
    private utility:Utility,
    private activeroute: ActivatedRoute

    ) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
    this.supportservice.GetAll().subscribe((res:any)=>{
      this.lstSupport=res;
      console.log(this.lstSupport);

    });

    if (this.activeroute.snapshot.params['id'] !== undefined) {

      this.editsupport.SupportId = this.activeroute.snapshot.params['id' ];
      this.supportservice.GetById(this.editsupport).subscribe(( res: any) => {

        this.objSupport = res;
        console.log(this.objSupport);
     });
      console.log(this.activeroute.snapshot.params['id' ] );

    }

  }
  AddSupport(){
    console.log(this.objSupport);
    if (this.objSupport.SupportId > 0 ) {
      this.supportservice.UpdateSupport(this.objSupport).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/Support/View']);
          console.log(res);
        }
        console.log(res);
      } );
    } else {
      this.supportservice.AddSupport(this.objSupport).subscribe(res => {
        console.log(res);
        if (res) {
          this.router.navigate(['/Support/View']);
          
        }
        
      } );

  }
}
}
