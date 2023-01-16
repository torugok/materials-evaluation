import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { QualityProperty } from '../models/QualityProperty';
import { Observable } from 'rxjs';

@Injectable()
export class QualityPropertyService {
  qualityPropertiesUrl = 'http://localhost:5000/api/quality-properties'; // FIXME: usar .env
  constructor(private http: HttpClient) {}

  getAll(): Observable<QualityProperty[]> {
    return this.http.get<QualityProperty[]>(this.qualityPropertiesUrl);
  }

  add(qualityProperty: QualityProperty): Observable<QualityProperty> {
    return this.http.post<QualityProperty>(
      this.qualityPropertiesUrl,
      qualityProperty
    );
  }

  edit(qualityProperty: QualityProperty): Observable<QualityProperty> {
    return this.http.put<QualityProperty>(
      `${this.qualityPropertiesUrl}/${qualityProperty.id}`,
      qualityProperty
    );
  }

  delete(id: number): Observable<any> {
    return this.http.delete<QualityProperty>(
      `${this.qualityPropertiesUrl}/${id}`
    );
  }
}
