import { Injectable, Inject } from '@angular/core';
import { TaxiRide} from '../taxi-ride'
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class TaxiService {

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  calculateFare(taxiRide: TaxiRide) {
    
    return this.http.post(this.baseUrl + 'TaxiFare', taxiRide, this.httpOptions);
  }
}
