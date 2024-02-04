import { Component, OnInit, inject, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { UserService } from '../../../../../../core/services/user.service';
import { RoleService } from '../../../../../../core/services/role.service';
import { RoleDto } from '../../../../../../core/models/security/role.model';

@Component({
  selector: 'app-update-user',
  standalone: true,
  imports: [ReactiveFormsModule, NgSelectModule],
  templateUrl: './update-user.component.html',
  styleUrl: './update-user.component.scss'
})
export class UpdateUserComponent implements OnInit{
  private router = inject(Router);
  private formbuilder = inject(FormBuilder);
  private userServie = inject(UserService);
  private rolesService = inject(RoleService);
  private route = inject(ActivatedRoute);

  public userId!:string | null;
  public userForm! : FormGroup;
  public roles = signal<RoleDto[]>([]);


  ngOnInit(): void {
    this.userId = this.route.snapshot.paramMap.get('id');
    this.updateForm();
    this.loadRoles();
    this.userServie.GetUserById(this.userId).subscribe({
      next: (user) => {
        this.userForm.patchValue({
          userName: user.userName,
          firstName: user.firstName,
          lastName: user.lastName,
          roleIds: user.roleIds
        });
      },
      error: (e) =>{
        console.error('Error al cargar los datos del usuario', e);
      }
    }
    );
  }


  public updateForm() {
    this.userForm = this.formbuilder.group({
      userId: [this.userId,Validators.required],
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
      this.userServie.UpdateUser(this.userId, this.userForm.value).subscribe({
        next: () => {
          this.router.navigate(['/administration/security/users']);
        },
        error: (e) => {
          console.error('Error al actualizar el usuario', e);
        }
      });
    }
  }

  public onCancel():void{
    this.router.navigate(['/administration/security/users']);
  }
}
