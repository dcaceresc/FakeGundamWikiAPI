import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faPlay } from '@fortawesome/free-solid-svg-icons';
import { MobileSuitVM } from '../../../../core/models/maintainer/mobile-suit.model';
import { MobileSuitsServiceService } from '../../../../core/services/mobile-suits-service.service';

@Component({
  selector: 'app-example-code',
  standalone: true,
  imports: [
    FontAwesomeModule,
    CommonModule
  ],
  templateUrl: './example-code.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ExampleCodeComponent { 

  private mobileSuitsService = inject(MobileSuitsServiceService);

  public tryItIcon = faPlay;
  showSecondDiv: boolean = false
  mobileSuit = signal<MobileSuitVM | null>(null);

  public onTryItClick(): void {
    this.showSecondDiv = true;
    this.mobileSuitsService.getMobileSuit('3').subscribe(mobileSuit => this.mobileSuit.set(mobileSuit));
  }
}
