import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LucideAngularModule, Trash2, Pencil } from 'lucide-angular';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';
import { ToolsbarDashboardComponent } from '../components/toolsbar-dashboard/toolsbar-dashboard.component';
import { MatDialog } from '@angular/material/dialog';
import { DialogAddComponent } from '../components/toolsbar-dashboard/dialog-add/dialog-add.component';

@Component({
  selector: 'app-dashboard',
  // standalone: true,
  imports: [CommonModule, ToolsbarDashboardComponent, LucideAngularModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  readonly Trash2 = Trash2;
  readonly Pencil = Pencil;

  users: User[] = [];
  dialog: any;

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe((data: User[]) => {
      this.users = data;
    });
  }

  openAddUserDialog(): void {
    const dialogRef = this.dialog.open(DialogAddComponent, {
      width: '800px',
    });

    dialogRef.afterClosed().subscribe((result: User) => {
      if (result) {
        console.log('New user added:', result);
        this.users.push(result);
      }
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
