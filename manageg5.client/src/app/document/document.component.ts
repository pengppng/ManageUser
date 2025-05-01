import { Component } from '@angular/core';
import { DocumentToolbarComponent } from '../components/toolbar-document/toolbar-document.component';
import { CommonModule } from '@angular/common';
import { Document } from '../models/document.model';
import { DocumentService } from '../services/document.service';

@Component({
  selector: 'app-document',
  standalone: true,
  imports: [CommonModule, DocumentToolbarComponent],
  templateUrl: './document.component.html',
  styleUrl: './document.component.css'
})
export class DocumentComponent {

  public documents: Document[] = [{ 
    id: "testdoc", 
    name: "Test", 
    description: "Long Test",
    createdAt: new Date(), 
  }];
  

  constructor(private documentsService: DocumentService) {
    console.log(this.documents)
  }


  // ngOnInit(): void {
  //   this.documentsService.getDocuments().subscribe((data: Document[]) => {
  //     this.documents = data;
  //   },);
  // }

  loadDocument(newdoc : Document): void {
    console.log('📦 Loading docs...');
    this.documents.push(newdoc);
    console.log('📥 doc loaded:', this.documents);
  }


  editDoc(document: Document): void {
      console.log('✏️ Editing Document:', document);
      // Add your edit dialog or logic here
    }
    
  deleteDoc(documents: Document): void {
      const confirmed = confirm(`Are you sure you want to delete ${documents.name}?`);
      if (confirmed) {
        this.documents = this.documents.filter(u => u.id !== documents.id);
        console.log('🗑️ User deleted:', documents);
      }
    }
}
