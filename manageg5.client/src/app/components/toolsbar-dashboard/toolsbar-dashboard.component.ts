import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-toolsbar-dashboard',
  // standalone: true,
  imports: [CommonModule],
  templateUrl: './toolsbar-dashboard.component.html',
  styleUrl: './toolsbar-dashboard.component.css'
})
export class ToolsbarDashboardComponent {
  sortOptions = ['Name', 'Date', 'Status'];
  selectedSort = 'Name';

  constructor() { }
}
