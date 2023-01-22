import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ApiError } from 'src/app/models/ApiError';
import { ErrorDialogComponent } from './error-dialog.component';

@Injectable()
export class ErrorDialogService {
  public isDialogOpen: Boolean = false;
  constructor(public dialog: MatDialog) {}
  openDialog(data: ApiError): any {
    if (this.isDialogOpen) {
      return false;
    }

    this.isDialogOpen = true;
    const dialogRef = this.dialog.open(ErrorDialogComponent, {
      width: '300px',
      data: data,
    });

    dialogRef.afterClosed().subscribe((result: any) => {
      this.isDialogOpen = false;
    });
  }
}
