import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
// import { LucideAngularModule, Trash2, Pencil } from 'lucide-angular';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';
import { ToolsbarDashboardComponent } from '../components/toolsbar-dashboard/toolsbar-dashboard.component';
import { MatDialog } from '@angular/material/dialog';
import { DialogAddComponent } from '../components/toolsbar-dashboard/dialog-add/dialog-add.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, ToolsbarDashboardComponent],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  // readonly Trash2 = Trash2;
  // readonly Pencil = Pencil;

  public users: User[] = []; //[{ id: "test", name: "Test", createdAt: new Date(), email: "", phoneNumber: "", role: { id: "", name: "", description: "", permissions: [] }, username: "", updatedAt: new Date() }];

  constructor(
    private userService: UserService,
    private dialog: MatDialog
    
  ) {
    console.log(this.users)
  }

  ngOnInit(): void {
    this.loadUsers();
  }
  
  loadUsers(): void {
    this.userService.getUsers().subscribe({
      next: (data) => {
        this.users = data;
        console.log('📥 Users loaded:', data);
        this.users = data;
      },
      error: (err) => {
        console.error('❌ Failed to load users:', err);
      }
    });
  }


  onUserAdded(user: User) {
    console.log('📢 Received userAdded event!',user);
    
    this.userService.addUser(user).subscribe({
      next: (res) => {
        console.log('✅ User added to backend!',res);
        this.loadUsers(); // โหลดใหม่จาก backend
      },
      error: err => {
        console.error('❌ Failed to add user:', err);
      }
    });
    // console.log('📢 Received userAdded event!');
    // this.loadUsers();
  }
  

  openAddUserDialog(): void {
    const dialogRef = this.dialog.open(DialogAddComponent, {
      width: '800px',
    });

    dialogRef.afterClosed().subscribe((result: User) => {
      if (result) {
        console.log('New user added:', result);
        // this.loadUsers(); // this.users.push(result);
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

  editUser(user: User): void {
    console.log('✏️ Editing user:', user);
    // Add your edit dialog or logic here
  }
  
  deleteUser(user: User): void {
    const confirmed = confirm(`Are you sure you want to delete ${user.name}?`);
    if (confirmed) {
      this.users = this.users.filter(u => u.id !== user.id);
      console.log('🗑️ User deleted:', user);
    }
  }

}
