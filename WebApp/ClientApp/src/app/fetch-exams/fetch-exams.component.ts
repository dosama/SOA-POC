import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServiceBusSender } from '../services/service-bus-sender.service';
import { ServiceBusSubscriber } from '../services/service-bus-subscriber.service';

@Component({
  selector: 'app-fetch-exams',
  templateUrl: './fetch-exams.component.html'
})
export class FetchExamsComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    
    http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}