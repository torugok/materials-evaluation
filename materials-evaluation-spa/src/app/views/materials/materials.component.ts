import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { MaterialDialogComponent } from './material-dialog/material-dialog.component';

export interface Material {
  id: number;
  name: string;
}

const MATERIALS_FAKE_DATA: Material[] = [
  { id: 1, name: 'Material 1' },
  { id: 2, name: 'Material 2' },
];

@Component({
  selector: 'app-materials',
  templateUrl: './materials.component.html',
  styleUrls: ['./materials.component.scss'],
})
export class MaterialsComponent {
  @ViewChild(MatTable)
  table!: MatTable<any>;
  displayedColumns: string[] = ['id', 'name', 'action'];
  dataSource = MATERIALS_FAKE_DATA;

  constructor(public dialog: MatDialog) {}

  openDialog(material: Material | null): void {
    const dialogRef = this.dialog.open(MaterialDialogComponent, {
      data:
        material === null
          ? { name: null }
          : { id: material.id, name: material.name },
    });

    dialogRef.afterClosed().subscribe((result: Material) => {
      if (result !== undefined) {
        if (this.dataSource.map((p) => p.id).includes(result.id)) {
          this.dataSource[result.id - 1] = result;
        } else {
          this.dataSource.push(result);
        }
        this.table.renderRows();
      }
    });
  }

  onDeleteMaterial(id: number): void {
    this.dataSource = this.dataSource.filter((material) => material.id !== id);
  }

  onEditMaterial(material: Material): void {
    this.openDialog(material);
  }
}
