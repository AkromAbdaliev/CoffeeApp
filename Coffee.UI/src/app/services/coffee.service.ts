import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment';

@Injectable({
  providedIn: 'root',
})
export class CoffeeService {
  private baseUrl = `${environment.apiUrl}/api/Coffee`;
  constructor(private http: HttpClient) {}

  getRecords() {
    return this.http.get(`${this.baseUrl}/getall`);
  }
}
