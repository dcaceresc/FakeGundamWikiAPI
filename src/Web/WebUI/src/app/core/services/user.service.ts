import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { CreateUserCommand, UpdateUserCommand, UserDto, UserVM } from '../models/administration/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private http = inject(HttpClient);

  public GetUsers() {
    return this.http.get<UserDto[]>('/api/Security/Users/GetUsers');
  }

  public GetUserById(id: string | null) {
    return this.http.get<UserVM>(`/api/Security/Users/GetUserById/${id}`);
  }

  public CreateUser(user: CreateUserCommand) {
    return this.http.post('/api/Security/Users/CreateUser', user);
  }

  public UpdateUser(id: string | null, user: UpdateUserCommand) {
    return this.http.put(`/api/Security/Users/UpdateUser/${id}`, user);
  }

  public ToggleUser(id: string | null) {
    return this.http.delete(`/api/Security/Users/ToggleUser/${id}`);
  }
}
