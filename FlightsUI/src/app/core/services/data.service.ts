import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Flight } from 'src/app/layout/search-flight/models';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private outboundFlight = new BehaviorSubject<Flight>({} as Flight);
  private returnFlight = new BehaviorSubject<Flight>({} as Flight);

  deptFlight = this.outboundFlight.asObservable();
  rtnFlight = this.returnFlight.asObservable();

  constructor() { }

  setFlights(deptFlight: Flight, rtnFlight: Flight){
    this.outboundFlight.next(deptFlight);
    this.returnFlight.next(rtnFlight);
  }
}
