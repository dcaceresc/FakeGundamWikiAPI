import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-universes',
  standalone: true,
  imports: [
    CommonModule,
  ],
  templateUrl: './universes.component.html',
  styleUrl: './universes.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UniversesComponent { }
