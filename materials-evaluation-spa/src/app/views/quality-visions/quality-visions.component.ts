import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { QualityProperty, QualityVision } from 'src/app/models/QualityVision';
import { QualityVisionService } from 'src/app/services/QualityVision.service';
import { handleApiErrors } from 'src/app/shared/utils/Errors';
import { QualityVisionDialogComponent } from './quality-vision-dialog/quality-vision.component';

@Component({
  selector: 'app-quality-visions',
  templateUrl: './quality-visions.component.html',
  styleUrls: ['./quality-visions.component.scss'],
  providers: [QualityVisionService],
})
export class QualityVisionsComponent {
  @ViewChild(MatTable)
  table!: MatTable<any>;
  displayedColumns: string[] = [
    //'id',
    'name',
    'action',
  ];
  dataSource!: QualityVision[];

  constructor(
    public dialog: MatDialog,
    public qualityVisionService: QualityVisionService
  ) {
    this.qualityVisionService.getAll().subscribe(
      (data: QualityVision[]) => {
        this.dataSource = data;
      },
      (err) => {
        handleApiErrors(err);
      }
    );
  }

  openDialog(qualityVision: QualityVision | null): void {
    const dialogRef = this.dialog.open(QualityVisionDialogComponent, {
      data:
        qualityVision === null
          ? { name: null }
          : { id: qualityVision.id, name: qualityVision.name },
    });

    dialogRef.afterClosed().subscribe((result: QualityVision) => {
      if (result !== undefined) {
        if (this.dataSource.map((p) => p.id).includes(result.id)) {
          // edição
          // FIXME: descomentar para adicionar a edição
          // this.qualityVisionService
          //   .edit(result)
          //   .subscribe((data: QualityProperty) => {
          //     var index = this.dataSource.findIndex(
          //       (item) => item.id === data.id
          //     );
          //     this.dataSource[index] = result;
          //     this.table.renderRows();
          //   });
        } else {
          // criação
          this.qualityVisionService.add(result).subscribe(
            () => {
              this.dataSource.push(result);
              this.table.renderRows();
            },
            (err) => {
              handleApiErrors(err);
            }
          );
        }
      }
    });
  }

  // FIXME: descomentar para adicionar a edição
  // onDeleteQualityVision(id: number): void {
  //   this.materialService
  //     .deleteQualityVision(id)
  //     .subscribe((data: QualityVision) => {
  //       this.dataSource = this.dataSource.filter(
  //         (material) => material.id !== id
  //       );
  //     });
  // }

  // onEditMaterial(material: Material): void {
  //   this.openDialog(material);
  // }
  //}
}
