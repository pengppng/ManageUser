import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, map, Observable, throwError } from 'rxjs';
import { User } from '../models/user.model';
import { UserServiceService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  private currentUserSubject = new BehaviorSubject<User | null>(null);
  public currentUser$ = this.currentUserSubject.asObservable();
  
  private isAuthenticatedSubject = new BehaviorSubject<boolean>(this.hasToken());
  public isAuthenticated$ = this.isAuthenticatedSubject.asObservable();

  constructor(private userService: UserServiceService) {
    const storedUser = localStorage.getItem('currentUser');
    if (storedUser) {
      this.currentUserSubject.next(JSON.parse(storedUser));
      this.isAuthenticatedSubject.next(true);
    }
  }

  login(username: string, password: string): Observable<User> {
    return this.userService.getUsers().pipe(
      map(users => {
        const user = users.find(u => u.username === username /* && u.password === password */);

        if (!user) {
          throw new Error('Username or password is incorrect');
        }

        // only admin
        if (user.role.name !== 'Admin') {
          throw new Error('User permission denied');
        }

        // if mem user และ token (mocked)
        localStorage.setItem('currentUser', JSON.stringify(user));
        localStorage.setItem('auth_token', 'fake-jwt-token');

        this.currentUserSubject.next(user);
        this.isAuthenticatedSubject.next(true);

        return user;
      }),
      catchError(error => {
        return throwError(() => error);
      })
    );
  }

  logout(): void {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('auth_token');
    this.currentUserSubject.next(null);
    this.isAuthenticatedSubject.next(false);
  }

  getCurrentUser(): User | null {
    return this.currentUserSubject.value;
  }

  private hasToken(): boolean {
    return !!localStorage.getItem('auth_token');
  }
}
