import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-manufacturers',
  standalone: true,
  imports: [CommonModule,],
  templateUrl: './manufacturers.component.html',
  styleUrl: './manufacturers.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ManufacturersComponent { }
