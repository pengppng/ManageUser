import { CommonModule } from '@angular/common'; 
import { Component, inject, model, NgModule, signal } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { ChangeDetectionStrategy } from '@angular/core';
import { DialogAddComponent } from './dialog-add/dialog-add.component';

@Component({
  selector: 'app-toolsbar-dashboard',
  // standalone: true,
  imports: [CommonModule,MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
  templateUrl: './toolsbar-dashboard.component.html',
  styleUrl: './toolsbar-dashboard.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})

export class ToolsbarDashboardComponent {
  sortOptions = ['Name', 'Date', 'Status'];
  selectedSort = 'Name';

  readonly animal = signal('');
  readonly name = model('');
  constructor(private readonly dialog: MatDialog) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogAddComponent, {
      data: {name: this.name(), animal: this.animal()},
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result !== undefined) {
        this.animal.set(result);
      }
    });
  }
}