import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LucideAngularModule, Trash2, Pencil } from 'lucide-angular';
import { User } from '../models/user.model';
import { UserServiceService } from '../services/user.service';
import { ToolsbarDashboardComponent } from '../components/toolsbar-dashboard/toolsbar-dashboard.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, ToolsbarDashboardComponent, LucideAngularModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  readonly Trash2 = Trash2;
  readonly Pencil = Pencil;

  users: User[] = [];

  constructor(private userService: UserServiceService) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe((data: User[]) => {
      this.users = data;
    });
  }

  getBadgeColor(role: any): string {
    if (!role || !role.name) return 'badge-default';
    switch (role.name) {
      case 'Employee': return 'badge-employee';
      default: return 'badge-default';
    }
  }
}