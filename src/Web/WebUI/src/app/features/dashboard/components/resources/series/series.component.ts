import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-series',
  standalone: true,
  imports: [
    CommonModule,
  ],
  templateUrl: './series.component.html',
  styleUrl: './series.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SeriesComponent { }
