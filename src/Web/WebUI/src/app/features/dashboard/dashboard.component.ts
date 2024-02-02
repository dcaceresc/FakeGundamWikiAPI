import { Component, OnInit, inject, signal } from '@angular/core';
import { NotificationService } from '../../core/services/notification.service';
import { faBook } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@Component({
  standalone: true,
  imports: [FontAwesomeModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent{

  public notificationService = inject(NotificationService);

  public docsIcon = faBook;
  
}
