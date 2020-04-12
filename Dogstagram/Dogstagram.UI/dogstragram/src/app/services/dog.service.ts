import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Dog } from '../Models/Dog';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class DogService {
  private dogPath  = environment.apiUrl + '/dogs';

  constructor(private http: HttpClient, private authService: AuthService) { 

  }

  create(data): Observable< Dog >{

    return this.http.post<Dog>(this.dogPath, data);
  }
}
