import { CommonModule } from '@angular/common'; 
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { ChangeDetectionStrategy } from '@angular/core';
import { Component, Output, EventEmitter } from '@angular/core';
import { DialogAddComponent } from './dialog-addd/dialog-addd.component';
import { Document } from '../../models/document.model'
import { DocumentService } from '../../services/document.service';


@Component({
  selector: 'app-toolsbar-document',
  standalone: true,
  imports: [CommonModule,MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
  templateUrl: './toolbar-document.component.html',
  styleUrl: './toolbar-document.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})

export class DocumentToolbarComponent {
  searchTerm = '';
  selectedTime = 'This Month';
  selectedType = 'Documents';

  // @Output() addDocument = new EventEmitter<Document>();
  // constructor(private dialog: MatDialog, private documentService: DocumentService) {}


  // name = '';
  // description = '';

  // onAdd() {const dialogRef = this.dialog.open(DialogAddComponent, {
  //   width: '400px',
  // });

  //   dialogRef.afterClosed().subscribe(result => {
  //     if (result) {
  //       const payload = {
  //         name: result.name,
  //         description: result.description
  //       };
  //       console.log('📤 Sending document payload:', payload);
  //       this.addDocument.emit(payload); // ส่ง Partial<Document>
  //     }
  //   });
  // }

  onAdd() {    console.log('Add new document');  }

  onSearchChange() {    console.log('Searching:', this.searchTerm);  }

  onLock() {    console.log('Lock clicked');  }

  onSelectAll() {    console.log('Select All clicked');  }

  onView() {    console.log('View clicked');  }

  onPrint() {    console.log('Print clicked');  }

  onDelete() {    console.log('Delete clicked');  }

  onTimeChange() {    console.log('Time changed to:', this.selectedTime);  }

  onTypeChange() {    console.log('Type changed to:', this.selectedType);  }
  
}
