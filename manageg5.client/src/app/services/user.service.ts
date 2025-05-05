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
    // return this.configService.get<User[]>('/users');
    return this.configService.get<User[]>('/Users');
  }

  getUserById(id: string): Observable<User> {
    return this.configService.get<User>("/Users/${id}");
  }
  // User
  addUser(payload: any): Observable<any> {
    console.log('📤 POST to backend with:', payload);
    return this.configService.post<any>('/Users', payload);
  }

  // createUser(user: any): Observable<any> {
  //   return this.configService.post<any>(`/User`, user);
  // }
  

  updateUser(id: string, user: User): Observable<User> {
    return this.configService.put<User>("/Users/${ id }", user);
  }

  deleteUser(id: string): Observable<User> {
    return this.configService.delete<User>("/Users/${ id }");
  }


}
