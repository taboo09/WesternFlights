import { Component, OnInit, Input } from '@angular/core';
import { Flight } from 'src/app/layout/search-flight/models';

@Component({
  selector: 'app-tile',
  templateUrl: './tile.component.html',
  styleUrls: ['./tile.component.scss']
})
export class TileComponent implements OnInit {

  @Input() flight: Flight;
  @Input() selected: boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
