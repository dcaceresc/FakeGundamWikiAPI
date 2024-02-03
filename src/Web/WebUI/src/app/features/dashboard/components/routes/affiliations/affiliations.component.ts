import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-affiliations',
  standalone: true,
  imports: [
    CommonModule,
  ],
  templateUrl: './affiliations.component.html',
  styleUrl: './affiliations.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AffiliationsComponent { }
