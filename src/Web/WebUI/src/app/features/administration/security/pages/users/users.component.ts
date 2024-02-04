import { Component, inject, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { TableComponent } from '../../../../../shared/components/table/table.component';
import { UserService } from '../../../../../core/services/user.service';
import { UserDto } from '../../../../../core/models/security/user.model';


@Component({
  selector: 'app-users',
  standalone: true,
  imports: [RouterLink,TableComponent],
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss'
})
export class UsersComponent {

  private userService = inject(UserService);
  private router = inject(Router);

  public users = signal<UserDto[]>([]);
  public columns:any[] = [];


  constructor() {
    this.userService.GetUsers().subscribe((users) => {
      this.users.set(users);
    });

    this.columns = [
      {key: 'userId', name : '#'},
      {key: 'userName', name: "Usuario"},
      {key: 'firstName', name: "Nombre"},
      {key: 'lastName', name: "Apellido"},
      {key: 'roleNames', name: "Permisos"},
      {key: 'isActive', name : "Acciones"}
    ]  
  }

  onEdit(id:number){
    this.router.navigate(['/administration/security/users/edit/', id]);
  }

  onToggle(id: number) {
    this.userService.ToggleUser(id.toString()).subscribe(() => {
      this.userService.GetUsers().subscribe((users) => {
        this.users.set(users);
      });
    });
  }

}
