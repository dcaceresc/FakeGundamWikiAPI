import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { CommonModule, DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faCircleUser, faKey } from '@fortawesome/free-solid-svg-icons';
import { AuthorizeService } from '../../../../../../core/services/authorize.service';

@Component({
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,FontAwesomeModule],
  templateUrl: './user-login.component.html',
  styleUrl: './user-login.component.scss'
})
export class UserLoginComponent implements OnInit, OnDestroy {
  

  private document = inject(DOCUMENT);
  private authorizeService = inject(AuthorizeService);
  private router = inject(Router);
  private formBuilder = inject(FormBuilder);

  public currentYear = new Date().getFullYear();
  public userForm! : FormGroup ;
  public errorMessage : string | null = null;
  public userIcon = faCircleUser;
  public passwordIcon = faKey;
  
  ngOnInit(): void {

    if(this.authorizeService.userValue){
      this.router.navigate(['/dashboard']);
    }

    this.createForm();
    this.document.body.style.backgroundColor = '#003087';
    
  }

  ngOnDestroy(): void {
    this.document.body.style.backgroundColor = '';
  }

  public createForm() {
    this.userForm = this.formBuilder.group({
      userName: ['',Validators.required],
      password: ['',Validators.required]
    });
  }

  public onSubmit():void{
    if(this.userForm.valid){


      this.authorizeService.login(this.userForm.value)
        .subscribe({
          next: () => {
            this.router.navigate(['/dashboard']);
          },
          error: (error) => {
            this.errorMessage = error;
          }
        }
      );
    }
  }

}


