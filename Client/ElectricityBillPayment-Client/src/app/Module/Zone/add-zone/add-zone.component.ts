import { Component, OnInit } from '@angular/core';
import { ZoneService } from 'src/app/Service/Zone/zone.service';

@Component({
  selector: 'app-add-zone',
  templateUrl: './add-zone.component.html',
  styleUrls: ['./add-zone.component.css']
})
export class AddZoneComponent implements OnInit {

  constructor(private zoneservice:ZoneService) { }

  ngOnInit(): void {
  }

}
