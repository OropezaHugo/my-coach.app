import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DesignerService {
  private presetSubject = new BehaviorSubject<boolean>(true);

  constructor() {}

  preset() {
    return this.presetSubject.value;
  }
}
