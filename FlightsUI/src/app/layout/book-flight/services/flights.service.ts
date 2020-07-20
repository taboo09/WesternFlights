import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { NewBookedFlight } from '../models';

@Injectable()
export class FlightsService {
  private bookedFlightUrl = environment.baseUrl + 'bookedflights/';
  
  constructor(private http: HttpClient) { }

  getSelectedSeats(flightId: number){
    return this.http.get<string[]>(this.bookedFlightUrl + 'seats/' + flightId);
  }

  bookFlight(flights: NewBookedFlight[]){
    return this.http.post<object>(this.bookedFlightUrl, flights);
  }
}
