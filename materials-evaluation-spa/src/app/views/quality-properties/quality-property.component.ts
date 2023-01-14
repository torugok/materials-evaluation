import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { QualityProperty } from 'src/app/models/QualityProperty';
import { QualityPropertyService } from 'src/app/services/QualityProperty.service';
import { QualityPropertyDialogComponent } from './quality-property-dialog/quality-property-dialog.component';

@Component({
  selector: 'app-materials',
  templateUrl: './quality-property.component.html',
  styleUrls: ['./quality-property.component.scss'],
  providers: [QualityPropertyService],
})
export class QualityPropertiesComponent {
  @ViewChild(MatTable)
  table!: MatTable<any>;
  displayedColumns: string[] = ['id', 'acronym', 'type', 'action'];
  dataSource!: QualityProperty[];

  constructor(
    public dialog: MatDialog,
    public qualityPropertyService: QualityPropertyService
  ) {
    this.qualityPropertyService
      .getAll()
      .subscribe((data: QualityProperty[]) => {
        this.dataSource = data;
      });
  }

  openDialog(qualityProperty: QualityProperty | null): void {
    const dialogRef = this.dialog.open(QualityPropertyDialogComponent, {
      data:
        qualityProperty === null
          ? { acronym: null, type: null }
          : {
              id: qualityProperty.id,
              acronym: qualityProperty.acronym,
              type: qualityProperty.type,
            },
    });

    dialogRef.afterClosed().subscribe((result: QualityProperty) => {
      if (result !== undefined) {
        // edição
        if (this.dataSource.map((p) => p.id).includes(result.id)) {
          this.qualityPropertyService
            .edit(result)
            .subscribe((data: QualityProperty) => {
              var index = this.dataSource.findIndex(
                (item) => item.id === data.id
              );
              this.dataSource[index] = result;
              this.table.renderRows();
            });
        } else {
          // criação
          this.qualityPropertyService
            .add(result)
            .subscribe((data: QualityProperty) => {
              this.dataSource.push(data);
              this.table.renderRows();
            });
        }
      }
    });
  }

  onDelete(id: number): void {
    this.qualityPropertyService
      .delete(id)
      .subscribe((data: QualityProperty) => {
        this.dataSource = this.dataSource.filter(
          (qualityProperty) => qualityProperty.id !== id
        );
      });
  }

  onEdit(qualityProperty: QualityProperty): void {
    this.openDialog(qualityProperty);
  }
}
