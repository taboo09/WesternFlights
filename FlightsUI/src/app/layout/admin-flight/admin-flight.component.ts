import { Component, OnInit } from '@angular/core';
import { FlightsService } from './services/flights.service';
import { SnackBarService } from 'src/app/core/services/snack-bar.service';
import { BookedFlight } from './models';
import { MatTableDataSource } from '@angular/material/table';

const DATA_LENGTH = 5;

@Component({
  selector: 'app-admin-flight',
  templateUrl: './admin-flight.component.html',
  styleUrls: ['./admin-flight.component.scss']
})
export class AdminFlightComponent implements OnInit {

  searchOccurs: boolean = false;
  finished: boolean = true;

  page: number = 0;
  flights: BookedFlight[] = [];
  dataSource: MatTableDataSource<BookedFlight>;
  tableColumns = ['icon', 'index', 'flightCode', 'customerName', 'seat', 'departureAirport', 'arrivalAirport', 'departureDate', 'arrivalDate', 'price' ];
  
  constructor(private flightService: FlightsService,
              private snackBarService: SnackBarService,) { }

  ngOnInit(): void {
    this.allFlights();
  }

  allFlights(){
    this.searchOccurs = true;
    this.page = 0;
    this.flights = [];
    this.getFlights();
  }

  getFlights(){
    this.flightService.getBookedFlights(this.page)
      .subscribe(data => {
        if(this.flights.length === 0 && data.length === 0){
          this.snackBarService.snackBarMessage('No flights could be found', 'Close', 'error');
        }

        this.flights = [...this.flights, ...data];

        console.log(this.flights);

        this.finished = data.length < DATA_LENGTH ? true : false;
        this.dataSource = new MatTableDataSource(this.flights);

      }, error => {
        console.log(error);

        this.snackBarService.snackBarMessage(error, 'Close', 'error');
      }, () => {
        this.searchOccurs = false;
      })
  }

  onScrollDown () {
    if (!this.finished){
      this.page = this.page + 1;
      this.getFlights();
    }
  }

}
