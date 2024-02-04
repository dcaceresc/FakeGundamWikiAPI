import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { AccountComponent } from './account/account.component';
import { AffiliationsComponent } from './affiliations/affiliations.component';
import { CharactersComponent } from './characters/characters.component';
import { MobileSuitsComponent } from './mobile-suits/mobile-suits.component';
import { ManufacturersComponent } from './manufacturers/manufacturers.component';
import { SeriesComponent } from './series/series.component';
import { UniversesComponent } from './universes/universes.component';

@Component({
  selector: 'app-resources',
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
  templateUrl: './resources.component.html',
  styleUrl: './resources.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ResourcesComponent { }
