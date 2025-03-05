import {
  ChangeDetectorRef,
  Component,
  effect,
  inject,
  input,
  OnChanges,
  OnInit,
  PLATFORM_ID,
  SimpleChanges
} from '@angular/core';
import {TrainingRecordContent, TrainingRecordModel} from '../../models/training-records.models';
import {ChartModule, UIChart} from 'primeng/chart';
import {AppConfigService} from '../../services/app-config.service';
import {DesignerService} from '../../services/designer.service';
import {isPlatformBrowser} from '@angular/common';
import {TrainingRecordService} from '../../services/training-record.service';
import {MatButton} from '@angular/material/button';

@Component({
  selector: 'app-user-training-records-tab',
  imports: [
    UIChart,
    MatButton
  ],
  templateUrl: './user-training-records-tab.component.html',
  styleUrl: './user-training-records-tab.component.scss'
})
export class UserTrainingRecordsTabComponent implements OnInit{
  userId = input.required<number>();
  exerciseId = input.required<number>();
  data: any;
  records: TrainingRecordContent[] = []
  options: any;
  platformId = inject(PLATFORM_ID);
  configService = inject(AppConfigService);
  trainingRecordService = inject(TrainingRecordService)
  designerService = inject(DesignerService);
  constructor(private cd: ChangeDetectorRef) {}

  themeEffect = effect(() => {
    if (this.configService.transitionComplete()) {
      if (this.designerService.preset()) {
        this.initChart();
      }
    }
  });

  refreshRecords(){
    this.trainingRecordService.getTrainingRecordsByUserIdAndExerciseId(this.userId() as number, this.exerciseId() as number).subscribe({
      next: (res) => {
        this.records = res
        this.initChart();
      }
    })
  }
  ngOnInit() {
    this.trainingRecordService.getTrainingRecordsByUserIdAndExerciseId(this.userId() as number, this.exerciseId() as number).subscribe({
      next: (res) => {
        this.records = res
        this.initChart();
      }
    })

  }

  initChart() {
    if (isPlatformBrowser(this.platformId)) {
      const documentStyle = getComputedStyle(document.documentElement);
      const textColor = 'white'
      const textColorSecondary = 'white'
      const surfaceBorder = 'white'

      this.data = {
        labels: this.records.map(value => value.recordDate),
        datasets: [
          {
            label: 'repetitions',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0.4,
            data: this.records.map(value => value.repetitionsMade)
          },
          {
            label: 'weight',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-gray-500'),
            yAxisID: 'y',
            tension: 0.4,
            data: this.records.map(value => value.weightLifted)
          }
        ]
      };

      this.options = {
        stacked: false,
        maintainAspectRatio: false,
        aspectRatio: 0.6,
        plugins: {
          legend: {
            labels: {
              color: textColor
            }
          }
        },
        scales: {
          x: {
            ticks: {
              color: textColorSecondary
            },
            grid: {
              color: surfaceBorder
            }
          },
          y: {
            type: 'linear',
            display: true,
            position: 'left',
            ticks: {
              color: textColorSecondary
            },
            grid: {
              color: surfaceBorder
            }
          }
        }
      };
      this.cd.markForCheck();
    }
  }
}
