import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MaterialBatch } from 'src/app/models/MaterialBatch';

@Component({
  selector: 'app-material-batch-dialog',
  templateUrl: './material-batch-dialog.component.html',
  styleUrls: ['./material-batch-dialog.component.scss'],
})
export class MaterialBatchDialogComponent {
  materialBatch!: MaterialBatch;
  isChange!: boolean;

  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: MaterialBatch,
    public dialogRef: MatDialogRef<MaterialBatchDialogComponent>
  ) {}

  ngOnInit(): void {
    if (this.data.id != null) {
      this.isChange = true;
    } else {
      this.isChange = false;
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
