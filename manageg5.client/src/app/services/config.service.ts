import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  //BASE_API = "http://localhost:5200/api/v1"
  BASE_API = "/api/v1";
  constructor(private httpCli: HttpClient) {}

  get<T>(subPath: string): Observable<T> {
    return this.httpCli.get<T>(this.BASE_API+subPath)
  }

  post<T>(subPath: string, body: any): Observable<T> {
    return this.httpCli.post<T>(this.BASE_API + subPath, body);
  }

  put<T>(subPath: string, body: any): Observable<T> {
    return this.httpCli.put<T>(this.BASE_API + subPath, body);
  }

  patch<T>(subPath: string, body: any): Observable<T> {
    return this.httpCli.patch<T>(this.BASE_API + subPath, body);
  }

  delete<T>(subPath: string): Observable<T> {
    return this.httpCli.delete<T>(this.BASE_API + subPath);
  }
  
}
