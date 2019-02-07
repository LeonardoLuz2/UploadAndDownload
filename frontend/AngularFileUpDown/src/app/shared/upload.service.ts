import { HttpClient, HttpRequest, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UploadService {

  API_URL = 'https://localhost:5000/api/upload';

  constructor(private http: HttpClient) { }

  uploadFile(file: any): Observable<HttpEvent<any>> {
    const formData: FormData = new FormData();
    formData.append('File', file);

    const req = new HttpRequest('POST', this.API_URL, formData, {
      reportProgress: true
    });
    return this.http.request(req);
  }
}
