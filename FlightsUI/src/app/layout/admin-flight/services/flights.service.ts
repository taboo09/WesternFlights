import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { BookedFlight } from '../models';

@Injectable()
export class FlightsService {
  private flightUrl = environment.baseUrl + 'bookedflights';
  
  constructor(private http: HttpClient) { }

  getBookedFlights(page: number){

    return this.http.get<BookedFlight[]>(this.flightUrl +'?page=' + page);

  }
}
