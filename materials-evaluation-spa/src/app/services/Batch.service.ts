import { Status } from './../models/Batch';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Batch } from '../models/Batch';
import { Observable } from 'rxjs';
import { TestResult } from '../models/QualityVision';

@Injectable()
export class BatchService {
  BatchesUrl = 'http://localhost:5000/api/batches'; // FIXME: usar .env
  constructor(private http: HttpClient) {}

  add(batch: Batch): Observable<Batch> {
    return this.http.post<Batch>(this.BatchesUrl, {
      materialId: batch.material.id,
      qualityVisionId: batch.qualityVision.id,
    });
  }

  addTest(batchId: string, testResults: TestResult[]): Observable<Batch> {
    return this.http.put<Batch>(`${this.BatchesUrl}/${batchId}/add-test`, {
      BatchId: batchId,
      tests: testResults,
    });
  }

  get(id: string): Observable<Batch> {
    return this.http.get<Batch>(`${this.BatchesUrl}/${id}`);
  }

  getAll(): Observable<Batch[]> {
    return this.http.get<Batch[]>(this.BatchesUrl);
  }

  checkTests(id: string): Observable<Status> {
    return this.http.post<Status>(`${this.BatchesUrl}/${id}/check-tests`, {});
  }

  delete(id: string): Observable<any> {
    return this.http.delete<any>(`${this.BatchesUrl}/${id}`);
  }
}
