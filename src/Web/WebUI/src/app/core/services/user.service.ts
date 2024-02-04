import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { CreateUserCommand, UpdateUserCommand, UserDto, UserVM } from '../models/security/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private http = inject(HttpClient);

  public GetUsers() {
    return this.http.get<UserDto[]>('/api/users');
  }

  public GetUserById(id: string | null) {
    return this.http.get<UserVM>(`/api/users/${id}`);
  }

  public CreateUser(user: CreateUserCommand) {
    return this.http.post('/api/users/create', user);
  }

  public UpdateUser(id: string | null, user: UpdateUserCommand) {
    return this.http.put(`/api/users/update/${id}`, user);
  }

  public ToggleUser(id: string | null) {
    return this.http.delete(`/api/users/toggle/${id}`);
  }
}
