import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { CreateRoleCommand, RoleDto, UpdateRoleCommand } from '../models/administration/role.model';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  private http = inject(HttpClient);

  public GetRoles() {
    return this.http.get<RoleDto[]>('/api/roles');
  }

  public GetRoleById(id: string | null) {
    return this.http.get<RoleDto>(`/api/roles/${id}`);
  }

  public CreateRole(role: CreateRoleCommand){
    return this.http.post('/api/roles/create', role);
  }

  public UpdateRole(id:string | null, role : UpdateRoleCommand){
    return this.http.put(`/api/roles/update/${id}`, role);
  }

  public ToggleRole(id:string | null){
    return this.http.delete(`/api/roles/toggle/${id}`);
  }
}
