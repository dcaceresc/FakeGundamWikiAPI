import { Component, OnInit, inject, signal } from '@angular/core';
import { NotificationService } from '../../core/services/notification.service';
import { faBook, faPlay } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ResourcesComponent } from './components/resources/resources.component';
import { RoutesComponent } from './components/routes/routes.component';

@Component({
  standalone: true,
  imports: [FontAwesomeModule,ResourcesComponent, RoutesComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent{

  public notificationService = inject(NotificationService);

  public docsIcon = faBook;
  public tryItIcon = faPlay;
  
}
