import { Status } from './../../models/Batch';
import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { Batch } from 'src/app/models/Batch';
import { BatchService } from 'src/app/services/Batch.service';
import { BatchDialogComponent } from './batch-dialog/batch-dialog.component';
import { convertToLocaleString } from 'src/app/shared/utils/Dates';
import { AddTestDialogComponent } from './add-test/add-test-dialog.component';
import { TestResult } from 'src/app/models/QualityVision';
import { Translations } from 'src/app/shared/utils/Translations';

@Component({
  selector: 'app-batches',
  templateUrl: './batches.component.html',
  styleUrls: ['./batches.component.scss'],
  providers: [BatchService],
})
export class BatchesComponent {
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
  dataSource!: Batch[];
  translations: typeof Translations;

  constructor(public dialog: MatDialog, public batchService: BatchService) {
    this.batchService.getAll().subscribe((data: Batch[]) => {
      this.dataSource = data;
      // convert timezone
      this.dataSource.forEach((batch, index) => {
        this.dataSource[index].createdAt = convertToLocaleString(
          batch.createdAt
        );
      });
    });
    this.translations = Translations;
  }

  openDialog(batch: Batch | null): void {
    const dialogRef = this.dialog.open(BatchDialogComponent, {
      // TODO: adicionar a edição corretamente
      data: batch === null ? { id: null } : { id: batch.id },
    });

    dialogRef.afterClosed().subscribe((result: Batch) => {
      if (result !== undefined) {
        if (this.dataSource.map((p) => p.id).includes(result.id)) {
          // edição
          // FIXME: descomentar ao implementar a edição
          // this.BatchService
          //   .editMaterial(result)
          //   .subscribe((data: Batch) => {
          //     var index = this.dataSource.findIndex(
          //       (item) => item.id === data.id
          //     );
          //     this.dataSource[index] = result;
          //     this.table.renderRows();
          //   });
        } else {
          // criação
          this.batchService.add(result).subscribe((data: Batch) => {
            this.batchService.get(data.id).subscribe((data: Batch) => {
              data.createdAt = convertToLocaleString(data.createdAt);
              this.dataSource.push(data);
              this.table.renderRows();
            });
          });
        }
      }
    });
  }

  onDelete(id: string): void {
    this.batchService.delete(id).subscribe((data: any) => {
      this.dataSource = this.dataSource.filter((element) => element.id !== id);
    });
  }

  onAddTest(batch: Batch) {
    const dialogRef = this.dialog.open(AddTestDialogComponent, {
      data: { ...batch },
    });

    dialogRef.afterClosed().subscribe((result: TestResult[]) => {
      if (result !== undefined) {
        this.batchService.addTest(batch.id, result).subscribe((data: any) => {
          batch.amountOfTests++;
        });
      }
    });
  }

  onCheckTests(batch: Batch) {
    this.batchService.checkTests(batch.id).subscribe((data: Status) => {
      batch.status = data;
    });
  }
}
