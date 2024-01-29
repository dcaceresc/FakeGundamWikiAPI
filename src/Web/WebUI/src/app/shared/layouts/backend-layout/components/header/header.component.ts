import { Component, inject } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faEnvelope, faRightFromBracket } from '@fortawesome/free-solid-svg-icons';
import { AdministrationMenuComponent } from '../../../../../features/administration/security/components/administration-menu/administration-menu.component';
import { AuthorizeService } from '../../../../../core/services/authorize.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [NgOptimizedImage, AdministrationMenuComponent,RouterLink,RouterLinkActive,FontAwesomeModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  
  public authorizeService = inject(AuthorizeService);
  public roles: string[] = [];
  public email = faEnvelope;
  public signOut = faRightFromBracket;

  constructor() {
    this.roles = this.authorizeService.getRoles();
  }


  public Logout() {
    this.authorizeService.logout();
  }
}
