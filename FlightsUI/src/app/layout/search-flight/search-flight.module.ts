import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SearchFlightRoutingModule } from './search-flight-routing.module';
import { SearchFlightComponent } from './search-flight.component';
import { SearchPanelComponent } from './components/search-panel/search-panel.component';
import { SearchResultComponent } from './components/search-result/search-result.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FlightsService } from './service/flights.service';
import { LoadingModule } from 'src/app/shared/modules/loading/loading.module';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { TileComponent } from './components/search-result/components/tile/tile.component';
import { MatDividerModule } from '@angular/material/divider';
import { MatCardModule } from '@angular/material/card';


@NgModule({
  declarations: [SearchFlightComponent, SearchPanelComponent, SearchResultComponent, TileComponent],
  imports: [
    CommonModule,
    SearchFlightRoutingModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTooltipModule,
    MatCheckboxModule,
    MatSelectModule,
    ReactiveFormsModule,
    LoadingModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDividerModule,
    MatCardModule
  ],
  providers: [
    FlightsService
  ]
})
export class SearchFlightModule { }
