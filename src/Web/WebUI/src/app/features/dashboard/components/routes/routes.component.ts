import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { AccountComponent } from './account/account.component';
import { AffiliationsComponent } from './affiliations/affiliations.component';
import { CharactersComponent } from './characters/characters.component';
import { ManufacturersComponent } from './manufacturers/manufacturers.component';
import { MobileSuitsComponent } from './mobile-suits/mobile-suits.component';
import { SeriesComponent } from './series/series.component';
import { UniversesComponent } from './universes/universes.component';

@Component({
  selector: 'app-routes',
  standalone: true,
  imports: [
    AccountComponent,
    AffiliationsComponent,
    CharactersComponent,
    ManufacturersComponent,
    MobileSuitsComponent,
    SeriesComponent,
    UniversesComponent
  ],
  templateUrl: './routes.component.html',
  styleUrl: './routes.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RoutesComponent { }
