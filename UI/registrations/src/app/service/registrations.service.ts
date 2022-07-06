import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Registration } from '../models/registrations.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrationsService {
  baseUrl = 'https://localhost:7236/api/registrations';
  constructor(private http: HttpClient) { }

  //Get all cards
  getAllRegistrations(): Observable<Registration[]> {
    return this.http.get<Registration[]>(this.baseUrl);

  }

  addRegistration(registration: Registration): Observable<Registration> {
    registration.id = "0";
    return this.http.post<Registration>(this.baseUrl, registration)
  }

  deleteRegistration(id: string): Observable<Registration> {
    return this.http.delete<Registration>(this.baseUrl + '/' + id);
  }

  updateRegistation(registration: Registration): Observable<Registration> {
    return this.http.put<Registration>(this.baseUrl + '/' + registration.id, registration);
  }

}
