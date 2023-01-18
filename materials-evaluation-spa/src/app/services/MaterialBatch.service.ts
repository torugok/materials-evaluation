import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MaterialBatch } from '../models/MaterialBatch';
import { Observable } from 'rxjs';
import { TestResult } from '../models/QualityVision';

@Injectable()
export class MaterialBatchService {
  materialBatchesUrl = 'http://localhost:5000/api/material-batches'; // FIXME: usar .env
  constructor(private http: HttpClient) {}

  add(materialBatch: MaterialBatch): Observable<MaterialBatch> {
    return this.http.post<MaterialBatch>(this.materialBatchesUrl, {
      materialId: materialBatch.material.id,
      qualityVisionId: materialBatch.qualityVision.id,
    });
  }

  addTest(
    materialBatchId: string,
    testResults: TestResult[]
  ): Observable<MaterialBatch> {
    return this.http.put<MaterialBatch>(
      `${this.materialBatchesUrl}/${materialBatchId}/add-test`,
      {
        materialBatchId: materialBatchId,
        tests: testResults,
      }
    );
  }

  get(id: string): Observable<MaterialBatch> {
    return this.http.get<MaterialBatch>(`${this.materialBatchesUrl}/${id}`);
  }

  getAll(): Observable<MaterialBatch[]> {
    return this.http.get<MaterialBatch[]>(this.materialBatchesUrl);
  }

  checkTests(id: string): Observable<any> {
    return this.http.post<any>(
      `${this.materialBatchesUrl}/${id}/check-tests`,
      {}
    );
  }

  delete(id: string): Observable<any> {
    return this.http.delete<any>(`${this.materialBatchesUrl}/${id}`);
  }
}
