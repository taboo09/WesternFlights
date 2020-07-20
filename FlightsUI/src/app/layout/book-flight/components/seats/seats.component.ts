import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

const rowSeats = ['a', 'b', 'c'];

@Component({
  selector: 'app-seats',
  templateUrl: './seats.component.html',
  styleUrls: ['./seats.component.scss']
})

export class SeatsComponent implements OnInit {

  @Input() rows: number;
  @Input() selectedSeats: string[];
  @Output() selection = new EventEmitter<string>();

  selectedSeat: string;
  availableSeats: any[] = [];

  constructor() { }

  ngOnInit(): void {
    this.createSeats();
  }

  createSeats(){
    for (let i = 1; i <= this.rows; i++) {

      rowSeats.forEach(s => {
        let seat = `${i}${s}`;
        let availableSeat = {
          seat: seat,
          taken: this.selectedSeats.indexOf(seat) >= 0 ? true : false
        };

        this.availableSeats.push(availableSeat);

      });
    }
  }

  seatIsSelected(seat){
    if (this.selectedSeat !== seat){
      this.selectedSeat = seat;
      this.selection.emit(seat);
    }
  }

}
