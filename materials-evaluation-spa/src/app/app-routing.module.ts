import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { MaterialsComponent } from './views/materials/materials.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'materials',
    component: MaterialsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
