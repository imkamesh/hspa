import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PropertyService {
  constructor(private http: HttpClient) {}
  getAllCities(): Observable<string[]>{
    return this.http.get<string[]>('http://localhost:48024/api/city');
  }  
}
