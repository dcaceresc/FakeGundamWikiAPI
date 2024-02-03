import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';

@Component({
  selector: 'app-frontend-layout',
  standalone: true,
  imports: [FontAwesomeModule,RouterOutlet,HeaderComponent,FooterComponent],
  templateUrl: './frontend-layout.component.html',
  styleUrl: './frontend-layout.component.scss'
})
export class FrontendLayoutComponent {

}
