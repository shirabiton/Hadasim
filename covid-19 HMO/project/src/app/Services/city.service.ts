import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { City } from '../Models/city';


@Injectable({
  providedIn: 'root'
})

export class CityService {
    baseUrl = 'https://localhost:7001/api/City';

  constructor(private _httpClient: HttpClient) { }

  
  getAllCities(): Observable<City[]> {
    return this._httpClient.get<City[]>(`${this.baseUrl}`)
  }
  getCityById(id: number): Observable<City> {
    return this._httpClient.get<City>(`${this.baseUrl}/${id}`)
  }
  postCity(city: City): Observable<City> {
    return this._httpClient.post<City>(`${this.baseUrl}`, city)
  }
  putCity(id:number, city: City): Observable<City> {
    return this._httpClient.put<City>(`${this.baseUrl}/${id}`, city)
  }
  deleteCity(id: number): Observable<City> {
    return this._httpClient.delete<City>(`${this.baseUrl}/${id}`)
  }
}


