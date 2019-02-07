import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, interval } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DownloadService {

  API_URL = 'https://localhost:5001/api/download';

  constructor(private http: HttpClient) { }

  getFiles(): Observable<string[]> {
    return this.http.get<string[]>(this.API_URL);
  }

  downloadFile(filename): Observable<any> {
    return this.http.get(`${this.API_URL}/${filename}`, { responseType: 'blob' });
  }
}
