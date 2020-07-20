import { Component, OnInit, Input } from '@angular/core';
import { Flight } from '../../models';
import { SnackBarService } from 'src/app/core/services/snack-bar.service';
import { DataService } from 'src/app/core/services/data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.scss']
})
export class SearchResultComponent implements OnInit {

  @Input() returnFlights: Flight[];
  @Input() departureFlights: Flight[];

  departureSelectedFlightId: number = 0;
  returnSelectedFlightId: number = 0;

  constructor(private snackBarService: SnackBarService,
              private dataService: DataService,
              private router: Router) { }

  ngOnInit(): void {
  }

  inputChecked(flightId, type){
    switch (type) {
      case 'dept':
        if (this.departureSelectedFlightId !== flightId) {
          this.departureSelectedFlightId = flightId;
    
          let time = this.departureFlights.find(x => x.flightId === flightId).departureDateTime.toLocaleTimeString();
    
          this.snackBarService.snackBarMessage('Flight from ' + time + ' has been selected', 'Ok', 'confirm')
        }
        break;
      default:
        if (this.returnSelectedFlightId !== flightId) {
          this.returnSelectedFlightId = flightId;
    
          let time = this.returnFlights.find(x => x.flightId === flightId).arrivalDateTime.toLocaleTimeString();
    
          this.snackBarService.snackBarMessage('Flight from ' + time + ' has been selected', 'Ok', 'confirm')
        }
        break;
    }
  }

  flightsAreSelected(){
    if (this.departureSelectedFlightId !== 0) {
      if (this.returnSelectedFlightId === 0) {
        return this.returnFlights ? false : true;
      }

      else return true;
    } 

    return false;
  }

  bookFlight(){
    let deptFlight = this.departureFlights.find(x => x.flightId === this.departureSelectedFlightId);
    let rtnFlight = this.returnSelectedFlightId === 0 ? undefined : this.returnFlights.find(x => x.flightId === this.returnSelectedFlightId);

    this.dataService.setFlights(deptFlight, rtnFlight);

    this.router.navigate(['/book-flight']);
  }
}
