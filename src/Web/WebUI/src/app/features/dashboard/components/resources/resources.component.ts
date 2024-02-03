import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-resources',
  standalone: true,
  imports: [
    CommonModule,
  ],
  templateUrl: './resources.component.html',
  styleUrl: './resources.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ResourcesComponent { }
