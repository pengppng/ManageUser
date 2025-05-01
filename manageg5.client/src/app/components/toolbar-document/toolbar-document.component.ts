import { CommonModule } from '@angular/common'; 
import { Component, model, signal } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { ChangeDetectionStrategy } from '@angular/core';
// import { DialogAddComponent } from './dialog-add/dialog-add.component';

@Component({
  selector: 'app-toolsbar-dashboard',
  // standalone: true,
  imports: [CommonModule,MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
  templateUrl: './toolbar-document.component.html',
  styleUrl: './toolbar-document.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})

export class DocumentToolbarComponent {
  searchTerm = '';
  selectedTime = 'This Month';
  selectedType = 'Documents';

  

  onSearchChange() {
    console.log('Searching:', this.searchTerm);
  }

  onLock() {
    console.log('Lock clicked');
  }

  onSelectAll() {
    console.log('Select All clicked');
  }

  onView() {
    console.log('View clicked');
  }

  onPrint() {
    console.log('Print clicked');
  }

  onDelete() {
    console.log('Delete clicked');
  }

  onTimeChange() {
    console.log('Time changed to:', this.selectedTime);
  }

  onTypeChange() {
    console.log('Type changed to:', this.selectedType);
  }

  onAdd() {
    console.log('Add new document');
  }
  
}
