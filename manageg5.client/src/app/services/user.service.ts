import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ConfigService } from './config.service';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private configService: ConfigService) { 
    // console.log('📦 UserService initialized');
  }

  getUsers(): Observable<User[]> {
    console.log('📦 Fetching users...');
    
    return this.configService.get<User[]>('/users');
  }

  getUserById(id: string): Observable<User> {
    return this.configService.get<User>('/users/${id}');
  }
  // User
  addUser(payload: User): Observable<any> {
    return this.configService.post<User>('/users', payload);
  }

  updateUser(id: string, user: User): Observable<User> {
    return this.configService.put<User>('/users/${ id }', user);
  }

  deleteUser(id: string): Observable<User> {
    return this.configService.delete<User>('/users/${ id }');
  }


}
