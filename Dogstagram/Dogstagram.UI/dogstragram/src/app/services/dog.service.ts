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

  getDogs():Observable<Array<Dog>> {    
    return this.http.get<Array<Dog>>(this.dogPath);
  }

  getDog(id):Observable<Dog> {
    return this.http.get<Dog>(this.dogPath + '/' + id);
  }

  deleteDog(id){
    return this.http.delete(this.dogPath + '/'+ id );
  }

  editDog(data){
    return this.http.put(this.dogPath, data);
  }
}
