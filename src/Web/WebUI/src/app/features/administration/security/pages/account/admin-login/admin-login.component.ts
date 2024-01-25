import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import {  DOCUMENT } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faCircleUser, faKey, faUserTie } from '@fortawesome/free-solid-svg-icons';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthorizeService } from '../../../../../../core/services/authorize.service';

@Component({
  standalone: true,
  imports: [ReactiveFormsModule,FontAwesomeModule],
  templateUrl: './admin-login.component.html',
  styleUrl: './admin-login.component.scss'
})
export class AdminLoginComponent implements OnInit, OnDestroy{

  private document = inject(DOCUMENT);
  private formBuilder = inject(FormBuilder);
  private router = inject(Router);
  private authorizeService = inject(AuthorizeService);

  public currentYear = new Date().getFullYear();
  public adminIcon = faUserTie;
  public passwordIcon = faKey;
  public userIcon = faCircleUser;
  public adminForm! : FormGroup ;
  public errorMessage : string | null = null;
  
  ngOnInit(): void {
    this.document.body.style.backgroundColor = '#e9ecf0';
    this.createForm();
  }

  ngOnDestroy(): void {
    this.document.body.style.backgroundColor = '';
  }


  public createForm() {
    this.adminForm = this.formBuilder.group({
      userName: ['',Validators.required],
      password: ['',Validators.required],
      supplanted : ['',Validators.required]
    });
  }

  public onSubmit():void{
    if(this.adminForm.valid){
      this.authorizeService.adminLogin(this.adminForm.value)
        .subscribe({
          next: () => {
            this.router.navigate(['/dashboard']);
          },
          error: (error) => {
            this.errorMessage = error;
          }
        });
    }
  }
}
