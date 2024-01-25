import { Component, EventEmitter, Input, Output, signal } from '@angular/core';;
import { faEdit, faPowerOff } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [CommonModule,FontAwesomeModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss'
})
export class TableComponent {
  @Input() data = signal<any[]>([]);
  @Input() columns:any[] = []
  @Output() editEvent : EventEmitter<number> = new EventEmitter<number>();
  @Output() toggleEvent : EventEmitter<number> = new EventEmitter<number>();

  public currentPage = signal(1);
  public readonly itemsPerPage = 10;
  public faEdit = faEdit;
  public faPowerOff = faPowerOff;


  public setPage(pageNumber: number) {
    this.currentPage.set(pageNumber);
  }

  public nPage(){
    return Math.ceil(this.data()?.length / this.itemsPerPage)
  }

  public range(start: number) {
    const result = [];
    for (let i = start; i <= this.nPage(); i++) {
      result.push(i);
    }
    return result;
  }

  public getPaginatedData(){
    const startIndex = (this.currentPage() - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    return this.data()?.slice(startIndex,endIndex);
  }


  public onEdit(id: number){
    this.editEvent.emit(id);
  }

  public onToggle(id: number) {
    this.toggleEvent.emit(id);
  }
}
