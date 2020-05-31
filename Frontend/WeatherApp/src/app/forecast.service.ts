import { Injectable } from '@angular/core';
import { Forecast } from './forecast';
import { Location } from './location';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { from, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ForecastService {

  constructor(
    private http: HttpClient) { }


  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private forecastUrl = 'https://localhost:44316/weatherforecast/api/sendAddress'; 

  GetForecast(location: Location) {
    return this.http.post(this.forecastUrl,location).
        pipe(
           map((data: any) => {
             return data;
           }), catchError( error => {
             return throwError( 'Something went wrong!' );
           })
        )
    }



}
