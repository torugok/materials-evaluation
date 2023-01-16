import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { MaterialsComponent } from './views/materials/materials.component';
import { QualityPropertiesComponent } from './views/quality-properties/quality-property.component';
import { QualityVisionsComponent } from './views/quality-visions/quality-visions.component';

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
  {
    path: 'qualidade/visoes',
    component: QualityVisionsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
