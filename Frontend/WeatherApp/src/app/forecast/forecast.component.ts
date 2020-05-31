import { Component, OnInit } from '@angular/core';
import { Forecast } from '../forecast';
import { Location } from '../location';
import { ForecastService } from '../forecast.service';
import { map } from 'rxjs/operators';
import { createOfflineCompileUrlResolver } from '@angular/compiler';

@Component({
  selector: 'app-forecast',
  templateUrl: './forecast.component.html',
  styleUrls: ['./forecast.component.css']
})
export class ForecastComponent implements OnInit {
  
  forecast: Forecast = {Sunrise: null, Sunset: null, Humidity: null , Temperature: null, RealFeel: null, UvIndex: null, WindSpeed: null };
  location: any = {};
  constructor(private forecastService: ForecastService) {}
  ngOnInit() {
    // this.getForecast();
  }

  getForecast(){
    this.forecastService.GetForecast(this.location).subscribe((response:any) => {
      this.forecast.Sunrise = response.sunrise
      this.forecast.Sunset = response.sunset
      this.forecast.UvIndex = response.uvIndex
      this.forecast.WindSpeed = response.windSpeed
      this.forecast.Temperature = response.temperature
      this.forecast.RealFeel = response.realFeel
      this.forecast.Humidity = response.humidity
    });
}
}
