import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { WeatherDataResponse } from '../models/WeatherDataResponse';
import { WeatherService } from '../services/weatherService';
import { EChartsOption, SeriesOption } from 'echarts/types/dist/echarts';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css', providers: [DatePipe]
})
export class AppComponent implements OnInit {

  isLoading = true;
  options: EChartsOption | null = null;

  constructor(private weatherService: WeatherService, private datePipe: DatePipe) { }

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.weatherService.getWeather()
      .subscribe(weatherData => {
        this._mapData(weatherData);
      })
  }

  private _locationDisplay(weatherData: WeatherDataResponse) {
    return `${weatherData.countryCode} : ${weatherData.cityName}`
  }

  private _mapData(weatherData: WeatherDataResponse[]) {

    this.isLoading = false;
    ;


    const legends = Array.from(new Set(weatherData.map(x => this._locationDisplay(x))));

    const uniqueTimes = Array.from(
      new Set(
        weatherData
          .map(x => this.datePipe.transform(new Date(x.timestamp), 'HH:mm'))
          .filter((time): time is string => time !== null)
      ));

    const locationsId = Array.from(new Set(weatherData.map(x => x.locationId)));

    const seriesOption: SeriesOption[] = [];

    locationsId.forEach(locationId => {
      seriesOption.push({
        name: this._locationDisplay(weatherData.find(w => w.locationId == locationId) ?? new WeatherDataResponse()),
        type: 'bar',
        data: weatherData.filter(w => w.locationId == locationId).map(x => x.temperatureInCelsius),
        animationDelay: idx => idx * locationId * 10,
      });
    })

    this.options = {
      legend: {
        data: legends,
        align: 'left',
      },
      tooltip: {},
      xAxis: {
        data: uniqueTimes,
        silent: true,
        splitLine: {
          show: true,
        },
      },
      yAxis: {},
      series: seriesOption,
      animationEasing: 'elasticOut',
      animationDelayUpdate: idx => idx * 5,
    };
  }
  title = 'secondtask.web.client';
}
