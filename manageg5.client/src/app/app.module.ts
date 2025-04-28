import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { MatDialogModule } from '@angular/material/dialog'; // Import MatDialogModule here
import { ToolsbarDashboardComponent } from './components/toolsbar-dashboard/toolsbar-dashboard.component';
import { DialogAddComponent } from './components/toolsbar-dashboard/dialog-add/dialog-add.component'; 

@NgModule({
  declarations: [ ],
  imports: [
    BrowserModule,
    MatDialogModule,
    AppComponent,
    ToolsbarDashboardComponent,
    DialogAddComponent,
  ],
  
})
export class AppModule {}
