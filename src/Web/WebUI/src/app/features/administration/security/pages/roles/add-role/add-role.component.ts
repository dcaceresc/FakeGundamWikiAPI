import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RoleService } from '../../../../../../core/services/role.service';

@Component({
  selector: 'app-add-role',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-role.component.html',
  styleUrl: './add-role.component.scss'
})
export class AddRoleComponent implements OnInit{
  

  private router = inject(Router);
  private formbuilder = inject(FormBuilder);
  private roleService = inject(RoleService);

  public roleForm!: FormGroup;

  ngOnInit(): void {
    this.createForm();
  }

  public createForm() {
    this.roleForm = this.formbuilder.group({
      roleName: ['', Validators.required],
    });
  }

  public onSubmit() {
    if(this.roleForm.valid){
      this.roleService.CreateRole(this.roleForm.value).subscribe( {
        next: () => {
          this.router.navigate(['administration/security/roles']);
        },
        error: (error) => {
          // Manejar el error
        }
      });
    }
  }

  public onCancel() {
    this.router.navigate(['/administration/security/roles']);
  }
}
