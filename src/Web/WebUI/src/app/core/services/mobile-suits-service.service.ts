import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { MobileSuitDto, MobileSuitVM } from '../models/maintainer/mobile-suit.model';

@Injectable({
  providedIn: 'root'
})
export class MobileSuitsServiceService {

  private http = inject(HttpClient);

  public getMobileSuits() {
    return this.http.get<MobileSuitDto[]>('/mobile-suits');
  }

  public getMobileSuit(id: string) {
    return this.http.get<MobileSuitVM>(`/api/mobile-suits/${id}`);
  }
}
