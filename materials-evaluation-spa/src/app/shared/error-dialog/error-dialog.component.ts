import { ApiError } from 'src/app/models/ApiError';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-root',
  templateUrl: './error-dialog.component.html',
  styleUrls: ['./error-dialog.component.scss'],
})
export class ErrorDialogComponent {
  title = 'Angular-Interceptor';
  constructor(@Inject(MAT_DIALOG_DATA) public data: ApiError) {}
}
