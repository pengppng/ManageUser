import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigService } from './config.service';
import { Role } from '../models/role.model';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  constructor(private configService: ConfigService) {}

  getRoles(): Observable<Role[]> {
    return this.configService.get<Role[]>('/Roles');
  }
}
