import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Member } from '../Models/member';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  baseUrl = 'https://localhost:7001/api/Member';

  constructor(private _httpClient: HttpClient) { }

  getAllMembers(): Observable<Member[]> {
    return this._httpClient.get<Member[]>(`${this.baseUrl}`)
  }

  getMemberById(id: number): Observable<Member> {
    return this._httpClient.get<Member>(`${this.baseUrl}/${id}`)
  }
  postMember(formData: FormData): Observable<Member> {
    return this._httpClient.post<Member>(`${this.baseUrl}`, formData)
  }
  putMember(id: number, formData: FormData): Observable<Member> {
    return this._httpClient.put<Member>(`${this.baseUrl}/${id}`, formData)
  }
  deleteMember(id: number): Observable<Member> {
    return this._httpClient.delete<Member>(`${this.baseUrl}/${id}`)
  }
}

