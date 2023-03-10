import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { QualityVision } from '../models/QualityVision';
import { Observable } from 'rxjs';

@Injectable()
export class QualityVisionService {
  qualityVisionsUrl = 'http://localhost:5000/api/quality-visions'; // FIXME: usar .env
  constructor(private http: HttpClient) {}

  add(qualityVision: QualityVision): Observable<QualityVision> {
    return this.http.post<QualityVision>(this.qualityVisionsUrl, qualityVision);
  }

  getAll(): Observable<QualityVision[]> {
    return this.http.get<QualityVision[]>(this.qualityVisionsUrl);
  }

  delete(id: string): Observable<any> {
    return this.http.delete<any>(`${this.qualityVisionsUrl}/${id}`);
  }
}
