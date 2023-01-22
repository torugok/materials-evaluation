import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Batch, Status } from 'src/app/models/Batch';
import {
  CalculationType,
  Grouping,
  TestResult,
} from 'src/app/models/QualityVision';

@Component({
  selector: 'app-add-test-dialog',
  templateUrl: './add-test-dialog.component.html',
  styleUrls: ['./add-test-dialog.component.scss'],
})
export class AddTestDialogComponent {
  batch!: Batch;
  isChange!: boolean;
  testResults!: TestResult[];

  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: Batch,
    public dialogRef: MatDialogRef<AddTestDialogComponent>
  ) {
    if (data.id === null) {
      this.data = {
        id: '',
        material: { id: '', name: '' },
        qualityVision: {
          id: '',
          name: '',
          materialId: '',
          avaliationMethodology: {
            minQuantity: 0,
            grouping: Grouping.Last,
            calculationType: CalculationType.Median,
          },
          qualityPropertiesIds: [],
        },
        createdAt: '',
        amountOfTests: 0,
        calculatedAt: '',
        status: Status.Pending,
        tests: [],
      };
    } else {
      this.data = data;
      this.testResults = [];
      data.qualityVision.qualityProperties?.forEach((qualityProperty) => {
        this.testResults.push({
          qualityPropertyId: qualityProperty.id,
          qualityPropertyDescription: qualityProperty.description,
          type: qualityProperty.type,
          resultQualitative:
            qualityProperty.type == 'Qualitative' ? false : null,
          resultQuantitative:
            qualityProperty.type == 'Quantitative' ? 0.0 : null,
          quantitativeParams: qualityProperty.quantitativeParams,
        });
      });
    }
  }

  ngOnInit(): void {
    // FIXME: descomentar quando fizer a edição
    // if (this.data.id != null) {
    //   this.isChange = true;
    // } else {
    //   this.isChange = false;
    // }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
