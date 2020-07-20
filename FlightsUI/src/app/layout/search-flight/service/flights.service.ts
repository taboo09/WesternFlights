import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Airport, SearchResult } from '../models';

@Injectable()
export class FlightsService {
  private flightUrl = environment.baseUrl + 'flight/';
  private airportUrl = environment.baseUrl + 'airport/';
  
  constructor(private http: HttpClient) { }

  getAirports(){
    return this.http.get<Airport[]>(this.airportUrl);
  }

  getFlightsResult(searchResult: SearchResult){

    let params = new HttpParams()
      .set('DepartureAirportId', searchResult.departureAirportId.toString())
      .set('ArrivalAirportId', searchResult.arrivalAirportId.toString())
      .set('DepartureDate', searchResult.departureDate.toLocaleDateString('en-US'));

    let params2;

    if (searchResult.returnDate !== undefined) {
      params2 = new HttpParams()
        .set('DepartureAirportId', searchResult.departureAirportId.toString())
        .set('ArrivalAirportId', searchResult.arrivalAirportId.toString())
        .set('DepartureDate', searchResult.departureDate.toLocaleDateString('en-US'))
        .set('ReturnDate', searchResult.returnDate.toLocaleDateString('en-US'));

      return this.http.get<any>(this.flightUrl,  { params: params2 } );
    }

    return this.http.get<any>(this.flightUrl,  { params: params } );
  }
}
