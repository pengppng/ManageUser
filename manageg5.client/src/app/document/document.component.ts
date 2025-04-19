import { Component } from '@angular/core';
import { LucideAngularModule, Pencil, Trash2 } from 'lucide-angular';
import { ToolsbarDashboardComponent } from '../components/toolsbar-dashboard/toolsbar-dashboard.component';
import { CommonModule } from '@angular/common';
import { Document } from '../models/document.model';
import { DocumentServiceService } from '../services/document.service';

@Component({
  selector: 'app-document',
  imports: [CommonModule, ToolsbarDashboardComponent, LucideAngularModule],
  templateUrl: './document.component.html',
  styleUrl: './document.component.css'
})
export class DocumentComponent {
  readonly Trash2 = Trash2;
  readonly Pencil = Pencil;

  documents: Document[] = [];

  constructor(private documentsService: DocumentServiceService) {}

  ngOnInit(): void {
    this.documentsService.getDocuments().subscribe((data: Document[]) => {
      this.documents = data;
    },);
  }
}
