import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { Material } from 'src/app/models/Material';
import { MaterialService } from 'src/app/services/Material.service';
import { handleApiErrors } from 'src/app/shared/utils/Errors';
import { MaterialDialogComponent } from './material-dialog/material-dialog.component';

@Component({
  selector: 'app-materials',
  templateUrl: './materials.component.html',
  styleUrls: ['./materials.component.scss'],
  providers: [MaterialService],
})
export class MaterialsComponent {
  @ViewChild(MatTable)
  table!: MatTable<any>;
  displayedColumns: string[] = [
    //'id',
    'name',
    'action',
  ];
  dataSource!: Material[];

  constructor(
    public dialog: MatDialog,
    public materialService: MaterialService
  ) {
    this.materialService.getMaterials().subscribe(
      (data: Material[]) => {
        this.dataSource = data;
      },
      (err) => {
        handleApiErrors(err);
      }
    );
  }

  openDialog(material: Material | null): void {
    const dialogRef = this.dialog.open(MaterialDialogComponent, {
      data:
        material === null
          ? { name: null }
          : { id: material.id, name: material.name },
    });

    dialogRef.afterClosed().subscribe((result: Material) => {
      if (result !== undefined) {
        // edição
        if (this.dataSource.map((p) => p.id).includes(result.id)) {
          this.materialService.editMaterial(result).subscribe(
            (data: Material) => {
              var index = this.dataSource.findIndex(
                (item) => item.id === data.id
              );
              this.dataSource[index] = result;
              this.table.renderRows();
            },
            (err) => {
              handleApiErrors(err);
            }
          );
        } else {
          // criação
          this.materialService.newMaterial(result).subscribe(
            (data: Material) => {
              this.dataSource.push(data);
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

  onDeleteMaterial(id: string): void {
    this.materialService.deleteMaterial(id).subscribe(
      (data: Material) => {
        this.dataSource = this.dataSource.filter(
          (material) => material.id !== id
        );
      },
      (err) => {
        handleApiErrors(err);
      }
    );
  }

  onEditMaterial(material: Material): void {
    this.openDialog(material);
  }
}
