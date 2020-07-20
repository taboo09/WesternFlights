import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookFlightRoutingModule } from './book-flight-routing.module';
import { BookFlightComponent } from './book-flight.component';
import { MatStepperModule } from '@angular/material/stepper';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatRadioModule } from '@angular/material/radio';
import { SeatsComponent } from './components/seats/seats.component';
import { FlightsService } from './services/flights.service';
import { LoadingModule } from 'src/app/shared/modules/loading/loading.module';


@NgModule({
  declarations: [BookFlightComponent, SeatsComponent],
  imports: [
    CommonModule,
    BookFlightRoutingModule,
    MatStepperModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatRadioModule,
    LoadingModule
  ],
  providers: [
    FlightsService
  ]
})
export class BookFlightModule { }
