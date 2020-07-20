import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminFlightRoutingModule } from './admin-flight-routing.module';
import { AdminFlightComponent } from './admin-flight.component';
import { MatTableModule } from '@angular/material/table'; 
import { FlightsService } from './services/flights.service';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { LoadingModule } from 'src/app/shared/modules/loading/loading.module';


@NgModule({
  declarations: [AdminFlightComponent],
  imports: [
    CommonModule,
    AdminFlightRoutingModule,
    MatTableModule,
    InfiniteScrollModule,
    LoadingModule
  ], 
  providers: [
    FlightsService
  ]
})
export class AdminFlightModule { }
