import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './services/auth.guard.service';


const routes: Routes = [
  {
    path: "",
    pathMatch: 'full',
    redirectTo: "/dashboard"
  },
  {
    path: "documents",
    pathMatch: "full",
    loadComponent: () => import("./document/document.component").then((m) => m.DocumentComponent),
    canActivate: [AuthGuardService]
  },
  {
    path: "dashboard",
    pathMatch: "full",
    loadComponent: () => import("./dashboard/dashboard.component").then((m) => m.DashboardComponent),
    canActivate: [AuthGuardService]
  },
  {
    path: "sign-in",
    pathMatch: "full",
    loadComponent: () => import("./sign-in/sign-in.component").then((m) => m.SignInComponent)
  },
  { path: '**', redirectTo: '/sign-in' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
