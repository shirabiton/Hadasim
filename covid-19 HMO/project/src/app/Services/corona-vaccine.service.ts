import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CoronaVaccine } from '../Models/corona-vaccine';

@Injectable({
  providedIn: 'root'
})

export class CoronaVaccineService {
  baseUrl = 'https://localhost:7001/api/CorornaVaccine';

  constructor(private _httpClient: HttpClient) {}

  getAllCoronaVaccines(): Observable<CoronaVaccine[]> {
    return this._httpClient.get<CoronaVaccine[]>(`${this.baseUrl}`);
  }

  getCoronaVaccineById(id: number): Observable<CoronaVaccine> {
    return this._httpClient.get<CoronaVaccine>(`${this.baseUrl}/${id}`);
  }

  postCoronaVaccine(coronaVaccine: CoronaVaccine): Observable<CoronaVaccine> {
    return this._httpClient.post<CoronaVaccine>(`${this.baseUrl}`, coronaVaccine);
  }

  putCoronaVaccine(id:number, coronaVaccine: CoronaVaccine): Observable<CoronaVaccine> {
    return this._httpClient.put<CoronaVaccine>(`${this.baseUrl}/${id}`, coronaVaccine);
  }

  deleteCoronaVaccine(id: number): Observable<CoronaVaccine> {
    return this._httpClient.delete<CoronaVaccine>(`${this.baseUrl}/${id}`);
  }
}
