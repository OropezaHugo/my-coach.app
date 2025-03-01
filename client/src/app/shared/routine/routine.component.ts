import {Component, input} from '@angular/core';

@Component({
  selector: 'app-routine',
  imports: [],
  templateUrl: './routine.component.html',
  styleUrl: './routine.component.scss'
})
export class RoutineComponent {
  userId = input.required<number>();
  routineId = input.required<number>();
  editable = input.required<boolean>();
}
