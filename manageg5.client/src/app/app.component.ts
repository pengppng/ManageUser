//import { HttpClient } from '@angular/common/http';
//import { Component, OnInit } from '@angular/core';

//interface WeatherForecast {
//  date: string;
//  temperatureC: number;
//  temperatureF: number;
//  summary: string;
//}

//@Component({
//  selector: 'app-root',
//  templateUrl: './app.component.html',
//  standalone: false,
//  styleUrl: './app.component.css'
//})
//export class AppComponent implements OnInit {
//  public forecasts: WeatherForecast[] = [];

//  constructor(private http: HttpClient) {}

//  ngOnInit() {
//    this.getForecasts();
//  }

//  getForecasts() {
//    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
//      (result) => {
//        this.forecasts = result;
//      },
//      (error) => {
//        console.error(error);
//      }
//    );
//  }

//  title = 'manageg5.client';
//}

import { Component } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { filter } from 'rxjs';
import { CommonModule } from '@angular/common';
import { LucideAngularModule } from 'lucide-angular';

@Component({
  selector: 'app-root',
  //  standalone: true,
  imports: [RouterOutlet, SidebarComponent, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  forecasts(forecasts: any) {
    throw new Error('Method not implemented.');
  }
  //ngOnInit(): void  {
  //  throw new Error('Method not implemented.');
  //}
  title = "Gofive-Admin-System"
  showSidebar = true;

  constructor(private router: Router) {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe((event: NavigationEnd) => {
      const hiddenRoutes = ['/sign-in'];
      const currentUrl = event.urlAfterRedirects.split('?')[0];

      this.showSidebar = !hiddenRoutes.includes(currentUrl);
    });
  }
}
