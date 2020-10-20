import { Injectable } from '@angular/core';
import { Observable, of,throwError  } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders  } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataserviceService {

  ServerURL = 'http://localhost:63500';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  GetGroup(): Observable<any> {
    return this.http.get(this.ServerURL + '/api/Group');
  };

  PostGroup(): Observable<any>{
    return this.http.post(this.ServerURL + '/api/Group','');
  }

  GetPackage(): Observable<any> {
    return this.http.get(this.ServerURL + '/api/Package');
  };

  PostPackage(): Observable<any>{
    return this.http.post(this.ServerURL + '/api/Package','');
  }

  GetTag(): Observable<any> {
    return this.http.get(this.ServerURL + '/api/Tag');
  };

  PostTag(): Observable<any>{
    return this.http.post(this.ServerURL + '/api/Tag','');
  }
}
