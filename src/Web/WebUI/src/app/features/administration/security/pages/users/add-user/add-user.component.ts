import { Component, OnInit, inject, signal } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgSelectModule } from '@ng-select/ng-select';
import { UserService } from '../../../../../../core/services/user.service';
import { RoleService } from '../../../../../../core/services/role.service';
import { RoleDto } from '../../../../../../core/models/security/role.model';

@Component({
  selector: 'app-add-user',
  standalone: true,
  imports: [ReactiveFormsModule,NgSelectModule],
  templateUrl: './add-user.component.html',
  styleUrl: './add-user.component.scss'
})
export class AddUserComponent implements OnInit {
  

  private router = inject(Router);
  private formbuilder = inject(FormBuilder);
  private userServie = inject(UserService);
  private rolesService = inject(RoleService);

  public userForm! : FormGroup;
  public roles = signal<RoleDto[]>([]);

  ngOnInit(): void {
    this.createForm();
    this.loadRoles();
  }


  public createForm() {
    this.userForm = this.formbuilder.group({
      userName: ['',Validators.required],
      firstName:['',Validators.required],
      lastName:['',Validators.required],
      roleIds : ['',Validators.required],
    });
  }

  public loadRoles(){
    this.rolesService.GetRoles().subscribe(
      (roles) => {
        this.roles.set(roles.filter(role => role.isActive));
      }
    )
  }

  public onSubmit():void{
    if(this.userForm.valid){
      this.userServie.CreateUser(this.userForm.value).subscribe( {
        next: () => {
          this.router.navigate(['administration/security/users']);
        },
        error: (error) => {
          // Manejar el error
        }
      });
    }
  }

  public onCancel():void{
    this.router.navigate(['/administration/security/users']);
  }
}
