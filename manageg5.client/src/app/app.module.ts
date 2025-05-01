import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { MatDialogModule } from '@angular/material/dialog';
import { ToolsbarDashboardComponent } from './components/toolsbar-dashboard/toolsbar-dashboard.component';
import { DialogAddComponent } from './components/toolsbar-dashboard/dialog-add/dialog-add.component';
import { DocumentToolbarComponent } from './components/toolbar-document/toolbar-document.component';
import { DialogAdddComponent } from './components/toolbar-document/dialog-addd/dialog-addd.component'; 

@NgModule({
  declarations: [ 
    
  
    DialogAdddComponent
  ],
  imports: [
    BrowserModule,
    MatDialogModule,
    AppComponent,
    ToolsbarDashboardComponent,
    DialogAddComponent,
    DocumentToolbarComponent
  ],
  
})
export class AppModule {}
