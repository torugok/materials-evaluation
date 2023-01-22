import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// external
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTableModule } from '@angular/material/table';
import { MaterialsComponent } from './views/materials/materials.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MaterialDialogComponent } from './views/materials/material-dialog/material-dialog.component';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';

// internal
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './views/home/home.component';
import { FooterComponent } from './shared/footer/footer.component';
import { SidenavComponent } from './shared/sidenav/sidenav.component';
import { QualityPropertiesComponent } from './views/quality-properties/quality-property.component';
import { QualityPropertyDialogComponent } from './views/quality-properties/quality-property-dialog/quality-property-dialog.component';
import { QualityVisionsComponent } from './views/quality-visions/quality-visions.component';
import { QualityVisionDialogComponent } from './views/quality-visions/quality-vision-dialog/quality-vision.component';
import { BatchesComponent } from './views/batches/batches.component';
import { BatchDialogComponent } from './views/batches/batch-dialog/batch-dialog.component';
import { AddTestDialogComponent } from './views/batches/add-test/add-test-dialog.component';
import { ErrorDialogComponent } from './shared/error-dialog/error-dialog.component';
import { ErrorDialogService } from './shared/error-dialog/error-dialog.service';
import { HttpConfigInterceptor } from './interceptors/httpconfig.interceptor';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FooterComponent,
    MaterialsComponent,
    MaterialDialogComponent,
    SidenavComponent,
    QualityPropertiesComponent,
    QualityPropertyDialogComponent,
    QualityVisionsComponent,
    QualityVisionDialogComponent,
    BatchesComponent,
    BatchDialogComponent,
    AddTestDialogComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatToolbarModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatFormFieldModule,
    FormsModule,
    MatInputModule,
    HttpClientModule,
    MatSidenavModule,
    MatDividerModule,
    MatListModule,
    MatCardModule,
    MatExpansionModule,
    MatMenuModule,
    MatSelectModule,
  ],
  providers: [
    ErrorDialogService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpConfigInterceptor,
      multi: true,
    },
  ],
  entryComponents: [ErrorDialogComponent],
  bootstrap: [AppComponent],
})
export class AppModule {}
