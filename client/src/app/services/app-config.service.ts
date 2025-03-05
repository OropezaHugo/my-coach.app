import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {

  private transitionCompleteSubject = new BehaviorSubject<boolean>(false);

  constructor() {
    setTimeout(() => this.transitionCompleteSubject.next(true), 2000);
  }

  transitionComplete() {
    return this.transitionCompleteSubject.value;
  }
}
