import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Material } from '../models/Material';
import { Observable } from 'rxjs';
import { CreatedEntity } from '../models/CreatedEntity';

@Injectable()
export class MaterialService {
  materialsUrl = 'http://localhost:5000/api/materials'; // FIXME: usar .env
  constructor(private http: HttpClient) {}

  getMaterials(): Observable<Material[]> {
    return this.http.get<Material[]>(this.materialsUrl);
  }

  newMaterial(material: Material): Observable<CreatedEntity> {
    return this.http.post<CreatedEntity>(this.materialsUrl, material);
  }

  editMaterial(material: Material): Observable<void> {
    return this.http.put<void>(`${this.materialsUrl}`, material);
  }

  deleteMaterial(id: string): Observable<void> {
    return this.http.delete<void>(`${this.materialsUrl}/${id}`);
  }
}
