import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MaterialBatch } from '../models/MaterialBatch';
import { Observable } from 'rxjs';

@Injectable()
export class MaterialBatchService {
  materialBatchesUrl = 'http://localhost:5000/api/material-batches'; // FIXME: usar .env
  constructor(private http: HttpClient) {}

  add(qualityVision: MaterialBatch): Observable<MaterialBatch> {
    return this.http.post<MaterialBatch>(
      this.materialBatchesUrl,
      qualityVision
    );
  }

  getAll(): Observable<MaterialBatch[]> {
    return this.http.get<MaterialBatch[]>(this.materialBatchesUrl);
  }
}
