import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HeaderComponent } from './components/header/header.component';

@Component({
  selector: 'app-frontend-layout',
  standalone: true,
  imports: [FontAwesomeModule,RouterOutlet,HeaderComponent],
  templateUrl: './frontend-layout.component.html',
  styleUrl: './frontend-layout.component.scss'
})
export class FrontendLayoutComponent {

}
