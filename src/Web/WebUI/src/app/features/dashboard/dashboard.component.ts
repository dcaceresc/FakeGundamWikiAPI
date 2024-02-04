import { Component, inject } from '@angular/core';
import { NotificationService } from '../../core/services/notification.service';
import { faBook } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ResourcesComponent } from './components/resources/resources.component';
import { ExampleCodeComponent } from './components/example-code/example-code.component';
import { RouterLink } from '@angular/router';

@Component({
  standalone: true,
  imports: [FontAwesomeModule,ResourcesComponent,ExampleCodeComponent,RouterLink],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent{

  public notificationService = inject(NotificationService);

  public docsIcon = faBook;
  
  
}
