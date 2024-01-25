import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { CreateRoleCommand, RoleDto, UpdateRoleCommand } from '../models/administration/role.model';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  private http = inject(HttpClient);

  public GetRoles() {
    return this.http.get<RoleDto[]>('/api/Security/Roles/GetRoles');
  }

  public GetRoleById(id: string | null) {
    return this.http.get<RoleDto>(`/api/Security/Roles/GetRoleById/${id}`);
  }

  public CreateRole(role: CreateRoleCommand){
    return this.http.post('/api/Security/Roles/CreateRole', role);
  }

  public UpdateRole(id:string | null, role : UpdateRoleCommand){
    return this.http.put(`/api/Security/Roles/UpdateRole/${id}`, role);
  }

  public ToggleRole(id:string | null){
    return this.http.delete(`/api/Security/Roles/ToggleRole/${id}`);
  }
}
