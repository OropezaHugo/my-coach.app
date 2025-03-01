import {Component, inject, input, OnInit} from '@angular/core';
import {TrainingPlanContent, UserTrainingPlanTrainingPlanCombined} from '../../models/training-plan.models';
import {TrainingPlanService} from '../../services/training-plan.service';
import {MatAccordion, MatExpansionPanel, MatExpansionPanelHeader} from '@angular/material/expansion';
import {MatIconButton} from '@angular/material/button';
import {MatIcon} from '@angular/material/icon';

@Component({
  selector: 'app-training-plan',
  imports: [
    MatAccordion,
    MatExpansionPanel,
    MatExpansionPanelHeader,
    MatIconButton,
    MatIcon
  ],
  templateUrl: './training-plan.component.html',
  styleUrl: './training-plan.component.scss'
})
export class TrainingPlanComponent implements OnInit {
  userId = input.required<number>();
  trainingPlanId = input.required<number>();
  editable = input.required<boolean>();
  trainingPlanService = inject(TrainingPlanService)
  trainingPlan? : TrainingPlanContent = undefined
  ngOnInit() {
    this.trainingPlanService.getTrainingPlanContentById(this.trainingPlanId() as number).subscribe({
      next: data => {
        this.trainingPlan = data;
      }
    })
  }
}
