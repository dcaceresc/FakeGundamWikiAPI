import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RoleService } from '../../../../../../core/services/role.service';

@Component({
  selector: 'app-update-role',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './update-role.component.html',
  styleUrl: './update-role.component.scss'
})
export class UpdateRoleComponent implements OnInit {
  
  private router = inject(Router);
  private route = inject(ActivatedRoute);
  private formbuilder = inject(FormBuilder);
  private roleService = inject(RoleService);

  public roleId!: string | null;
  public roleForm!: FormGroup;

  ngOnInit(): void {
    this.roleId = this.route.snapshot.paramMap.get('id');
    this.updateForm();
    this.roleService.GetRoleById(this.roleId).subscribe({
      next: (role) => {
        this.roleForm.patchValue({
          roleName: role.roleName
        });
      },
      error: (e) => {
        console.error('Error al cargar los datos del rol', e);
      }
    });
  }

  public onSubmit() {
    if(this.roleForm.valid){
      this.roleService.UpdateRole(this.roleId, this.roleForm.value).subscribe( {
        next: () => {
          this.router.navigate(['administration/security/roles']);
        },
        error: (error) => {
          // Manejar el error
        }
      });
    }
  }

  public updateForm() {
    this.roleForm = this.formbuilder.group({
      roleId: [this.roleId, Validators.required],
      roleName: ['', Validators.required]
    });
  }

  public onCancel() {
    this.router.navigate(['/administration/security/roles']);
  }
}
