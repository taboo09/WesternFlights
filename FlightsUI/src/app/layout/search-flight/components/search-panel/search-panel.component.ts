import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { Airport } from '../../models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-panel',
  templateUrl: './search-panel.component.html',
  styleUrls: ['./search-panel.component.scss']
})
export class SearchPanelComponent implements OnInit {
  
  @Input() airports: Airport[];
  @Output() searchResult = new EventEmitter<object>();

  flightForm: FormGroup;
  departureIdSelected: number;
  returnSelected: boolean = true;

  @ViewChild(FormGroupDirective) flightFormpDirective: FormGroupDirective;

  constructor(private fb: FormBuilder,
              private router: Router) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.flightForm = this.fb.group({
      departureId: ['', [Validators.required]],
      arrivalId: ['', [Validators.required]],
      departureDate: ['', [Validators.required]],
      returnDate: ['', [Validators.required]]
    });
  }

  selectReturnFlight(){
    if (!this.returnSelected){
      this.flightForm.get('returnDate').disable();
    }
    else {
      this.flightForm.get('returnDate').enable();
    }
  }

  OnDateChange(event){
    this.flightForm.controls['returnDate'].setValue(event);
  }

  departureChanged(event){
    this.departureIdSelected = event.value;
    this.flightForm.controls.arrivalId.setValue('');
  }

  swapAirports(){
    let tempDepartureId = this.flightForm.controls.departureId.value;

    this.flightForm.controls.departureId.setValue(this.flightForm.controls.arrivalId.value);
    this.flightForm.controls.arrivalId.setValue(tempDepartureId);
  }

  searchForFlights(){
    this.searchResult.emit(this.flightForm.value);

    // reset form
    setTimeout(() => this.flightFormpDirective.resetForm(), 0)
  }

}
