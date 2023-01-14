import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { QualityProperty } from 'src/app/models/QualityProperty';

@Component({
  selector: 'app-quality-property-dialog',
  templateUrl: './quality-property-dialog.component.html',
  styleUrls: ['./quality-property-dialog.component.scss'],
})
export class QualityPropertyDialogComponent {
  qualityProperty!: QualityProperty;
  isChange!: boolean;

  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: QualityProperty,
    public dialogRef: MatDialogRef<QualityPropertyDialogComponent>
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
