import { Component, inject, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { TableComponent } from '../../../../../shared/components/table/table.component';
import { RoleService } from '../../../../../core/services/role.service';
import { RoleDto } from '../../../../../core/models/security/role.model';

@Component({
  selector: 'app-roles',
  standalone: true,
  imports: [RouterLink,TableComponent],
  templateUrl: './roles.component.html',
  styleUrl: './roles.component.scss'
})
export class RolesComponent {
  private roleService = inject(RoleService);
  private router = inject(Router);

  public users = signal<RoleDto[]>([]);
  public columns:any[] = [];

  constructor() {
    this.roleService.GetRoles().subscribe((roles) => {
      this.users.set(roles);
    });

    this.columns = [
      {key: 'roleId', name : '#'},
      {key: 'roleName', name: "Nombre"},
      {key: 'isActive', name : "Acciones"}
    ]  
  }

  public onEdit(id:number){
    this.router.navigate(['/administration/security/roles/edit/', id]);
  }

  public onToggle(id:number){
    this.roleService.ToggleRole(id.toString()).subscribe(() => {
      this.roleService.GetRoles().subscribe((roles) => {
        this.users.set(roles);
      });
    });
  }
  
}
