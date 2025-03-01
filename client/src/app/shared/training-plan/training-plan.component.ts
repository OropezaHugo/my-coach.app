import {Component, input} from '@angular/core';

@Component({
  selector: 'app-training-plan',
  imports: [],
  templateUrl: './training-plan.component.html',
  styleUrl: './training-plan.component.scss'
})
export class TrainingPlanComponent {
  userId = input.required<number>();
  trainingPlanId = input.required<number>();
  editable = input.required<boolean>();
}
