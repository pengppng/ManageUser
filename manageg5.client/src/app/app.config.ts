import { ApplicationConfig, importProvidersFrom } from "@angular/core";
import { provideRouter } from "@angular/router";
import { routes } from "./app.routing";
import { FileText, LayoutDashboard, LogOut, LucideAngularModule } from "lucide-angular";
import { provideHttpClient } from "@angular/common/http";

export const appConfig : ApplicationConfig = {
    providers: [provideRouter(routes), provideHttpClient()],
    
    };