import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  effect,
  inject,
  input,
  OnInit,
  PLATFORM_ID, signal, viewChild,
} from '@angular/core';
import {TrainingRecordContent, TrainingRecordModel} from '../../models/training-records.models';
import {UIChart} from 'primeng/chart';
import {AppConfigService} from '../../services/app-config.service';
import {DesignerService} from '../../services/designer.service';
import {DatePipe, isPlatformBrowser} from '@angular/common';
import {TrainingRecordService} from '../../services/training-record.service';
import {MatButton, MatIconButton} from '@angular/material/button';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort, MatSortHeader} from '@angular/material/sort';
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderCellDef, MatHeaderRow, MatHeaderRowDef, MatNoDataRow, MatRow, MatRowDef,
  MatTable,
  MatTableDataSource
} from '@angular/material/table';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {MatIcon} from '@angular/material/icon';

@Component({
  selector: 'app-user-training-records-tab',
  imports: [
    UIChart,
    MatButton,
    MatLabel,
    MatInput,
    MatFormField,
    MatSort,
    MatTable,
    MatColumnDef,
    MatHeaderCell,
    MatCell,
    MatCellDef,
    MatHeaderCellDef,
    MatRowDef,
    MatHeaderRow,
    MatRow,
    MatNoDataRow,
    MatPaginator,
    DatePipe,
    MatSortHeader,
    MatHeaderRowDef,
    MatIconButton,
    MatIcon
  ],
  templateUrl: './user-training-records-tab.component.html',
  styleUrl: './user-training-records-tab.component.scss'
})
export class UserTrainingRecordsTabComponent implements OnInit, AfterViewInit{
  userId = input.required<number>();
  exerciseId = input.required<number>();
  chartView = signal<boolean>(false)
  columns: string[] = ['weightLifted', 'repetitionsMade', 'recordDate','actions']
  data: any;
  records: TrainingRecordContent[] = []
  options: any;
  platformId = inject(PLATFORM_ID);
  trainingRecordService = inject(TrainingRecordService)
  dataSource:MatTableDataSource<TrainingRecordContent> = new MatTableDataSource()
  paginator = viewChild.required<MatPaginator>(MatPaginator)
  sort = viewChild.required<MatSort>(MatSort)
  cd = inject(ChangeDetectorRef)

  ngOnInit() {
    this.trainingRecordService.getTrainingRecordsByUserIdAndExerciseId(this.userId() as number, this.exerciseId() as number).subscribe({
      next: (res) => {
        this.records = res
        this.dataSource = new MatTableDataSource(res);
        this.initChart();
      }
    })
  }

  ngAfterViewInit() {
    this.trainingRecordService.getTrainingRecordsByUserIdAndExerciseId(this.userId() as number, this.exerciseId() as number).subscribe({
      next: (res) => {
        this.records = res
        this.dataSource = new MatTableDataSource(res);
        this.initChart();

        this.dataSource.sort = this.sort();
        this.dataSource.paginator = this.paginator();
      }
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filterPredicate = (rec, filter) => rec.recordDate.trim().toLowerCase().includes(filter)

    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  refreshRecords(){
    this.trainingRecordService.getTrainingRecordsByUserIdAndExerciseId(this.userId() as number, this.exerciseId() as number).subscribe({
      next: (res) => {
        this.records = res
        this.initChart();
        this.dataSource.data = res;
        this.dataSource.sort = this.sort();
        this.dataSource.paginator = this.paginator();
      }
    })
  }
  deleteRecord(id:number){
    this.trainingRecordService.deleteRecordById(id).subscribe({
      next: (res) => {
        this.trainingRecordService.getTrainingRecordsByUserIdAndExerciseId(this.userId() as number, this.exerciseId() as number).subscribe({
          next: (res) => {
            this.records = res
            this.initChart();
            this.dataSource.data = res;
            this.dataSource.sort = this.sort();
            this.dataSource.paginator = this.paginator();
          }
        })
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

  loadTableView() {
    this.trainingRecordService.getTrainingRecordsByUserIdAndExerciseId(this.userId() as number, this.exerciseId() as number).subscribe({
      next: (res) => {
        this.records = res
        this.initChart();
        this.dataSource.data = res;
        this.chartView.set(!this.chartView())
      }
    })
  }
}
