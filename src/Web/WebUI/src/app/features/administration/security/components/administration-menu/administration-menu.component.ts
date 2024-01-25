import { Component, ElementRef, ViewChild, inject } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faChevronRight, faUser, faUserGear } from '@fortawesome/free-solid-svg-icons';
import { AuthorizeService } from '../../../../../core/services/authorize.service';

@Component({
  selector: 'app-administration-menu',
  standalone: true,
  imports: [RouterLink,RouterLinkActive,FontAwesomeModule],
  templateUrl: './administration-menu.component.html',
  styleUrl: './administration-menu.component.scss'
})
export class AdministrationMenuComponent{

  private authorizeService = inject(AuthorizeService);
  @ViewChild('btnCloseOffCanvas') btnCloseOffCanvas!: ElementRef;

  public isSuperAdmin: boolean = false;
  public ChevronRight = faChevronRight;
  public User = faUser;
  public Role = faUserGear;

  constructor() {
    this.isSuperAdmin = this.authorizeService.isSuperAdmin();
  }

  public onClose(){
    this.btnCloseOffCanvas.nativeElement.click();
  }

}
