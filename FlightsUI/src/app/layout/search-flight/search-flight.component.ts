import { Component, OnInit } from '@angular/core';
import { FlightsService } from './service/flights.service';
import { Airport, SearchResult, Flight } from './models';
import { SnackBarService } from 'src/app/core/services/snack-bar.service';

@Component({
  selector: 'app-search-flight',
  templateUrl: './search-flight.component.html',
  styleUrls: ['./search-flight.component.scss']
})
export class SearchFlightComponent implements OnInit {
  airports: Airport[] = [];
  departureFlights: Flight[];
  returnFlights: Flight[];
  flightSearchInProgress: boolean = false;

  constructor(private flightService: FlightsService,
              private snackBarService: SnackBarService) { }

  ngOnInit(): void {
    this.getAirports();
   
  }

  getAirports(){
    this.flightService.getAirports()
      .subscribe(data => {
        this.airports = data;
      }, error => {
        this.snackBarService.snackBarMessage(error, 'Close', 'error');
      })
  }

  flightSearch(obj){
    // display loading
    this.flightSearchInProgress = true;

    let searchResult: SearchResult = {
      departureAirportId: obj.departureId,
      arrivalAirportId: obj.arrivalId,
      departureDate: obj.departureDate,
      returnDate: obj.returnDate === undefined ? undefined : obj.returnDate
    };

    this.flightService.getFlightsResult(searchResult)
      .subscribe(data => {
        
        this.departureFlights = data.departureFlights;
        this.returnFlights = data.returnFlights;    

      }, error => {
        this.snackBarService.snackBarMessage(error, 'Close', 'error');
      }, () => {
        this.flightSearchInProgress = false;
      })
  }

}

