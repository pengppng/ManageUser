import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ConfigService } from './config.service';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private configService: ConfigService) { }

  getUsers(): Observable<User[]> {
    return this.configService.get<User[]>('/users');
  }

  getUserById(id: string): Observable<User> {
    return this.configService.get<User>('/users/${id}');
  }

  addUser(user: User): Observable<User> {
    return this.configService.post<User>('/users', user);
  }

  updateUser(id: string, user: User): Observable<User> {
    return this.configService.put<User>('/users/${ id }', user);
  }

  deleteUser(id: string): Observable<User> {
    return this.configService.delete<User>('/users/${ id }');
  }


}
