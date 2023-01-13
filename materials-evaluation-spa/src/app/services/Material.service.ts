import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Material } from '../models/Material';
import { Observable } from 'rxjs';

@Injectable()
export class MaterialService {
  materialsUrl = 'http://localhost:5000/api/Materials'; // FIXME: usar .env
  constructor(private http: HttpClient) {}

  getMaterials(): Observable<Material[]> {
    return this.http.get<Material[]>(this.materialsUrl);
  }

  newMaterial(material: Material): Observable<Material> {
    return this.http.post<Material>(this.materialsUrl, material);
  }

  editMaterial(material: Material): Observable<Material> {
    return this.http.put<Material>(
      `${this.materialsUrl}/${material.id}`,
      material
    );
  }

  deleteMaterial(id: number): Observable<any> {
    return this.http.delete<Material>(`${this.materialsUrl}/${id}`);
  }
}
