import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TopsecretService {

  private authApiURI = "https://localhost:5001/api";
  constructor(private http: HttpClient) { }

  fetchTopSecretData() {   
    
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': "token"
      })
    };
 
   return this.http.get(this.authApiURI + '/weatherforecast');
  }
}
