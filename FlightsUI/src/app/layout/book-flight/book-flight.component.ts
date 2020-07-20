import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DataService } from 'src/app/core/services/data.service';
import { Flight } from '../search-flight/models';
import { Router } from '@angular/router';
import { SnackBarService } from 'src/app/core/services/snack-bar.service';
import { FlightsService } from './services/flights.service';
import { NewBookedFlight } from './models';

@Component({
  selector: 'app-book-flight',
  templateUrl: './book-flight.component.html',
  styleUrls: ['./book-flight.component.scss']
})
export class BookFlightComponent implements OnInit {

  customerForm: FormGroup;
  deptFlight: Flight;
  rtnFlight: Flight;
  deptFlightSeats: string[];
  rtnFlightSeats: string[];
  deptSeat: string;
  rtnSeat: string;

  constructor(private fb: FormBuilder,
              private dataService: DataService,
              private flightsService: FlightsService,
              private snackBarService: SnackBarService,
              private router: Router) { }

  ngOnInit(): void {
    this.getFlights();

    this.createForm();  
  }

  getFlights(){
    this.dataService.deptFlight
      .subscribe(data => {
        // navigate to search page if flight is null
        if (JSON.stringify(data) === '{}' ) this.router.navigate(['/search-flight']);

        this.deptFlight = data;
      });

    this.dataService.rtnFlight
      .subscribe(data => {
        
        this.rtnFlight = data;
      });
  }

  selectionChange(stepperIndex){
    switch (stepperIndex) {
      case 1:
        this.flightsService.getSelectedSeats(this.deptFlight.flightId)
          .subscribe(data => {
            this.deptFlightSeats = data;
          }, error => {
            this.snackBarService.snackBarMessage(error, 'Close', 'error');
          })
        break;

      case 2:
        if(this.rtnFlight.flightId === 0) break;

        this.flightsService.getSelectedSeats(this.rtnFlight.flightId)
          .subscribe(data => {
            this.rtnFlightSeats = data;
          }, error => {
            this.snackBarService.snackBarMessage(error, 'Close', 'error');
          })
        break;
    
      default:
        break;
    }
  }

  createForm(){
    this.customerForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(36)]],
      city: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(24)]],
      country: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(24)]],
      address: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(50)]]
    });
  }

  deptSeatSelected(seat){
    this.deptSeat = seat;
  }

  returnSeatSelected(seat){
    this.rtnSeat = seat;
  }

  seatsWereSelected(){
    if (!this.deptSeat) return false;

    if(this.rtnFlight?.flightId && !this.rtnSeat) return false;

    return true;
  }

  done(){
    let flights: NewBookedFlight[] = [];

    let outboundFlight: NewBookedFlight = {
      customerName: this.customerForm.get('name').value,
      seat: this.deptSeat,
      flightId: this.deptFlight.flightId
    };

    flights.push(outboundFlight);

    if (this.rtnFlight) {
      flights.push(
        {
          customerName: this.customerForm.get('name').value,
          seat: this.rtnSeat,
          flightId: this.rtnFlight.flightId
        }
      );
    }
    
    this.flightsService.bookFlight(flights)
      .subscribe(response => {

        this.snackBarService.snackBarMessage(response["message"], 'Thank You!', 'confirm');

      }, error => {
        this.snackBarService.snackBarMessage(error, 'Close', 'error');
    });

    setTimeout(() => {
      this.router.navigate(['/search-flight']);
    }, 1000);

  }

}
