import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { MaterialsComponent } from './views/materials/materials.component';
import { QualityPropertiesComponent } from './views/quality-properties/quality-property.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'materiais',
    component: MaterialsComponent,
  },
  {
    path: 'qualidade/caracteristicas',
    component: QualityPropertiesComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
