import { CommonModule } from '@angular/common'; 
import { Component, inject, model, signal, EventEmitter, Output } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { ChangeDetectionStrategy } from '@angular/core';
import { DialogAddComponent } from './dialog-add/dialog-add.component';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-toolsbar-dashboard',
  standalone: true,
  imports: [CommonModule,MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule, MatDialogModule],
  templateUrl: './toolsbar-dashboard.component.html',
  styleUrl: './toolsbar-dashboard.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})

export class ToolsbarDashboardComponent {
  sortOptions = ['Name', 'Date', 'Status'];
  selectedSort = 'Name';

  @Output() addUser = new EventEmitter<User>();

  constructor(private dialog: MatDialog, private userService: UserService) {}

  openDialog(): void {
    console.log('📣 opening dialog...');
    const dialogRef = this.dialog.open(DialogAddComponent, {
      width: '800px'
    });

    dialogRef.afterClosed().subscribe((result: any) => {
      if (result) {
        const payload: any = {
          Id: result.userId,
          Name: result.firstName + ' ' + result.lastName,
          Email: result.email,
          Username: result.username,
          PhoneNumber: result.mobileNo,
          CreatedAt: new Date(),
          UpdatedAt: new Date(),
          RoleId: result.roleType,
          // Role: {
          //   Id: 'AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 
          //   Name: 'Super Admin' }
          
        };

        // this.addUser.emit(payload)

        this.userService.addUser(payload).subscribe({
          next: () => {
            console.log('✅ User created successfully');
            this.addUser.emit(payload); // แจ้ง Dashboard โหลดข้อมูลใหม่
          },
          error: (err) => {
            console.error('❌ Failed to create user:', err);
          }
        });
        console.log('📣 Dialog closed with result:', result);
      }
    });
  
  }


}