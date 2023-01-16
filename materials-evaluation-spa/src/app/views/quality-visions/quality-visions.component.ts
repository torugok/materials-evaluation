import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { QualityVision } from 'src/app/models/QualityVision';
import { QualityVisionService } from 'src/app/services/QualityVision.service';
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
    public materialService: QualityVisionService
  ) {
    this.materialService.getAll().subscribe((data: QualityVision[]) => {
      this.dataSource = data;
    });
  }

  openDialog(material: QualityVision | null): void {
    const dialogRef = this.dialog.open(QualityVisionDialogComponent, {
      data:
        material === null
          ? { name: null }
          : { id: material.id, name: material.name },
    });
  }
}
// FIXME: descomentar para adicionar a edição
//   dialogRef.afterClosed().subscribe((result: QualityVision) => {
//     if (result !== undefined) {
//       // edição
//       if (this.dataSource.map((p) => p.id).includes(result.id)) {
//         this.materialService
//           .editQualityVision(result)
//           .subscribe((data: QualityVision) => {
//             var index = this.dataSource.findIndex(
//               (item) => item.id === data.id
//             );
//             this.dataSource[index] = result;
//             this.table.renderRows();
//           });
//       } else {
//         // criação
//         this.materialService
//           .newQualityVision(result)
//           .subscribe((data: QualityVision) => {
//             this.dataSource.push(data);
//             this.table.renderRows();
//           });
//       }
//     }
//   });
// }

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
