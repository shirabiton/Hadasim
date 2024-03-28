import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Manufacturer } from '../Models/manufacturer';

@Injectable({
  providedIn: 'root'
})
export class ManufacturerService {
  baseUrl = 'https://localhost:7001/api/Manufacturer';

  constructor(private _httpClient: HttpClient) { }

  getAllManufacturers(): Observable<Manufacturer[]> {
    return this._httpClient.get<Manufacturer[]>(`${this.baseUrl}`)
  }
  getManufacturerById(id: number): Observable<Manufacturer> {
    return this._httpClient.get<Manufacturer>(`${this.baseUrl}/${id}`)
  }
  postManufacturer(manufacturer: Manufacturer): Observable<Manufacturer> {
    return this._httpClient.post<Manufacturer>(`${this.baseUrl}`, manufacturer)
  }
  putManufacturer(id:number, manufacturer: Manufacturer): Observable<Manufacturer> {
    return this._httpClient.put<Manufacturer>(`${this.baseUrl}/${id}`, manufacturer)
  }
  deleteManufacturer(id: number): Observable<Manufacturer> {
    return this._httpClient.delete<Manufacturer>(`${this.baseUrl}/${id}`)
  }
}

