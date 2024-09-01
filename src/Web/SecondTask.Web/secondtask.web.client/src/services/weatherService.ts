import {HttpClient} from '@angular/common/http';
import {environment} from '../environments/environment';
import {Injectable} from '@angular/core';
import {map, Observable} from 'rxjs';
import {WeatherDataResponse} from '../models/WeatherDataResponse';


@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  constructor(private http: HttpClient) {
  }

  getWeather(): Observable<WeatherDataResponse[]> {
    return this.http.get<WeatherDataResponse[]>(`${environment.apiUrl}weatherdata`).pipe(
      map(data => data.map(item => ({
        ...item,
        timestamp: new Date(item.timestamp) // Convert the string to a Date object for each item
      })))
    );
  }

}
