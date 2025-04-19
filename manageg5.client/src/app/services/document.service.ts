import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigService } from './config.service';
import { Document } from '../models/document.model';

@Injectable({
  providedIn: 'root'
})
export class DocumentServiceService {

  constructor(private configService: ConfigService) { }

  getDocuments(): Observable<Document[]> {
    return this.configService.get<Document[]>('/documents');
  }

  getDocumentById(id: string): Observable<Document> {
    return this.configService.get<Document>(`/documents/${id}`);
  }

  addDocument(document: Document): Observable<Document> {
    return this.configService.post<Document>('/documents', document);
  }

  updateDocument(id: string, document: Document): Observable<Document> {
    return this.configService.put<Document>(`/documents/${id}`, document);
  }

  deleteDocument(id: string): Observable<void> {
    return this.configService.delete<void>(`/documents/${id}`);
  }
}
