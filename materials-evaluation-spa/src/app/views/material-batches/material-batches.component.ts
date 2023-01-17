import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { MaterialBatch } from 'src/app/models/MaterialBatch';
import { MaterialBatchService } from 'src/app/services/MaterialBatch.service';
import { MaterialBatchDialogComponent } from './material-batch-dialog/material-batch-dialog.component';
import { convertToLocaleString } from 'src/app/shared/utils/Dates';

@Component({
  selector: 'app-material-batches',
  templateUrl: './material-batches.component.html',
  styleUrls: ['./material-batches.component.scss'],
  providers: [MaterialBatchService],
})
export class MaterialBatchesComponent {
  @ViewChild(MatTable)
  table!: MatTable<any>;
  displayedColumns: string[] = [
    //'id',
    'materialName',
    'qualityVisionName',
    'createdAt',
    'minQuantity',
    'grouping',
    'calculationType',
    'amountOfTests',
    'status',
    'action',
  ];
  dataSource!: MaterialBatch[];

  constructor(
    public dialog: MatDialog,
    public materialBatchService: MaterialBatchService
  ) {
    this.materialBatchService.getAll().subscribe((data: MaterialBatch[]) => {
      this.dataSource = data;
      // convert timezone
      this.dataSource.forEach((materialBatch, index) => {
        this.dataSource[index].createdAt = convertToLocaleString(
          materialBatch.createdAt
        );
      });
    });
  }

  openDialog(materialBatch: MaterialBatch | null): void {
    const dialogRef = this.dialog.open(MaterialBatchDialogComponent, {
      // TODO: adicionar a edição corretamente
      data: materialBatch === null ? { id: null } : { id: materialBatch.id },
    });

    dialogRef.afterClosed().subscribe((result: MaterialBatch) => {
      if (result !== undefined) {
        if (this.dataSource.map((p) => p.id).includes(result.id)) {
          // edição
          // FIXME: descomentar ao implementar a edição
          // this.materialBatchService
          //   .editMaterial(result)
          //   .subscribe((data: MaterialBatch) => {
          //     var index = this.dataSource.findIndex(
          //       (item) => item.id === data.id
          //     );
          //     this.dataSource[index] = result;
          //     this.table.renderRows();
          //   });
        } else {
          // criação
          this.materialBatchService
            .add(result)
            .subscribe((data: MaterialBatch) => {
              this.materialBatchService
                .get(data.id)
                .subscribe((data: MaterialBatch) => {
                  data.createdAt = convertToLocaleString(data.createdAt);
                  this.dataSource.push(data);
                  this.table.renderRows();
                });
            });
        }
      }
    });
  }

  onAddTest(materialBatch: MaterialBatch) {
    console.log(materialBatch);
  }
}
