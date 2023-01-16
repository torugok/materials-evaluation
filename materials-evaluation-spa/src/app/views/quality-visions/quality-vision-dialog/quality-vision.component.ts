import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Material } from 'src/app/models/Material';
import { QualityProperty } from 'src/app/models/QualityProperty';
import {
  CalculationType,
  Grouping,
  QualityVision,
} from 'src/app/models/QualityVision';
import { MaterialService } from 'src/app/services/Material.service';
import { QualityPropertyService } from 'src/app/services/QualityProperty.service';
import { QualityVisionService } from 'src/app/services/QualityVision.service';

@Component({
  selector: 'app-quality-vision-dialog',
  templateUrl: './quality-vision-dialog.component.html',
  //styleUrls: ['./quality-vision-dialog.component.scss'],
  providers: [MaterialService, QualityPropertyService],
})
export class QualityVisionDialogComponent {
  isChange!: boolean;
  materialsOptions!: Material[];
  qualityPropertiesOptions!: QualityProperty[];

  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: QualityVision,
    public dialogRef: MatDialogRef<QualityVisionDialogComponent>,
    public materialService: MaterialService,
    public qualityPropertiesService: QualityPropertyService
  ) {
    if (data.name === null) {
      this.data = {
        id: '',
        name: '',
        materialId: '',
        avaliationMethodology: {
          minQuantity: 0,
          grouping: Grouping.Last,
          calculationType: CalculationType.Median,
        },
        qualityPropertiesIds: [],
      };
    } else {
      this.data = data;
    }
    this.materialService.getMaterials().subscribe((data: Material[]) => {
      this.materialsOptions = data;
    });
    this.qualityPropertiesService
      .getAll()
      .subscribe((data: QualityProperty[]) => {
        this.qualityPropertiesOptions = data;
      });
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

  onAddQualityPropertyOption(): void {
    this.data.qualityPropertiesIds.push('');
  }

  onRemoveQualityProperty(index: number): void {
    this.data.qualityPropertiesIds.splice(index, 1);
  }
}
