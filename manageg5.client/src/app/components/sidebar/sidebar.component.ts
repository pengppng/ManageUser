import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router'; 
import { LucideAngularModule, LayoutDashboard, FileText, LogOut  } from 'lucide-angular';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterModule, LucideAngularModule,CommonModule], 
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {
  constructor() {}

  ngOnInit() {
    console.log('Sidebar initialized');}
    
  readonly LayoutDashboard = LayoutDashboard;
  readonly FileText = FileText;
  readonly LogOut = LogOut;
  
  onSignOut() {
    console.log('Signed out');
  }
}
