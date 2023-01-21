import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Material } from 'src/app/models/Material';
import { Batch, Status } from 'src/app/models/Batch';
import {
  CalculationType,
  Grouping,
  QualityVision,
} from 'src/app/models/QualityVision';
import { MaterialService } from 'src/app/services/Material.service';
import { QualityVisionService } from 'src/app/services/QualityVision.service';
import { handleApiErrors } from 'src/app/shared/utils/Errors';

@Component({
  selector: 'app-material-batch-dialog',
  templateUrl: './material-batch-dialog.component.html',
  styleUrls: ['./material-batch-dialog.component.scss'],
  providers: [MaterialService, QualityVisionService],
})
export class BatchDialogComponent {
  batch!: Batch;
  isChange!: boolean;
  materialsOptions!: Material[];
  qualityVisionsOptions!: QualityVision[];

  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: Batch,
    public dialogRef: MatDialogRef<BatchDialogComponent>,
    public materialService: MaterialService,
    public qualityVisionService: QualityVisionService
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
    }
    this.materialService.getMaterials().subscribe(
      (data: Material[]) => {
        this.materialsOptions = data;
      },
      (err) => {
        handleApiErrors(err);
      }
    );
    this.qualityVisionService.getAll().subscribe(
      (data: QualityVision[]) => {
        this.qualityVisionsOptions = data;
      },
      (err) => {
        handleApiErrors(err);
      }
    );
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
