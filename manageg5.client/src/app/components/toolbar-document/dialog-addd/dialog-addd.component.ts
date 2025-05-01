import { MatDialogRef } from '@angular/material/dialog';
import { Component, ChangeDetectionStrategy, inject, model, signal } from '@angular/core';

import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { merge } from 'rxjs';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-dialog-add',
  templateUrl: './dialog-addd.component.html',
  styleUrl: './dialog-addd.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    /*MatDialogClose,*/
    MatSelectModule,
  ],
})
export class DialogAdddocComponent {
  name = '';
  description = '';

  constructor(public dialogRef: MatDialogRef<DialogAdddocComponent>) {}

  save() {
    if (!this.name || !this.description) return;
    this.dialogRef.close({
      name: this.name,
      description: this.description,
    });
  }

  cancel() {
    this.dialogRef.close();
  }
}
