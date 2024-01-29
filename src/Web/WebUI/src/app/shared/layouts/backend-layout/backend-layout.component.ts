import { Component } from '@angular/core';
import { HeaderComponent } from './components/header/header.component';
import { RouterOutlet } from '@angular/router';

@Component({
  standalone: true,
  imports: [HeaderComponent,RouterOutlet],
  templateUrl: './backend-layout.component.html',
  styleUrl: './backend-layout.component.scss'
})
export class BackEndLayoutComponent {

}
