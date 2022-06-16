import { Component, OnInit } from '@angular/core';
import { TaxiRide } from '../taxi-ride'
import { TaxiService } from './taxi.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-taxi',
  templateUrl: './taxi.component.html',
  styleUrls: ['./taxi.component.css']
})
export class TaxiComponent implements OnInit {

  public totalFare: number = 0;
  public taxiRide: TaxiRide;

  constructor(private taxiService: TaxiService) { }

  ngOnInit() {
    let datePipe = new DatePipe('en-US');

    this.taxiRide = {
      milesUnder6Mph: 0,
      minutesOver6Mph: 0,
      startDateOfRide: datePipe.transform(new Date(), 'yyyy-MM-dd'),
      startTimeOfRide: datePipe.transform(new Date(), 'HH:mm'),
      totalFare: 0
    };
  }

  public calculateFare() {
    this.taxiService.calculateFare(this.taxiRide)
      .subscribe(
        (next: number) => this.totalFare = next,
        (error) => {
          console.error(`Error occurred while calling Taxi Service: ${error}`);
          this.totalFare = 0;
        }
      );
  }
}
