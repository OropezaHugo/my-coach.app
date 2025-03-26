import {
  AfterViewInit,
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component, computed,
  inject,
  input,
  OnInit,
  PLATFORM_ID,
  signal,
  viewChild,
} from '@angular/core';
import {TrainingRecordContent} from '../../models/training-records.models';
import {UIChart} from 'primeng/chart';
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
  MatHeaderCellDef,
  MatHeaderRow,
  MatHeaderRowDef,
  MatNoDataRow,
  MatRow,
  MatRowDef,
  MatTable,
  MatTableDataSource
} from '@angular/material/table';
import {MatError, MatFormField, MatHint, MatLabel, MatSuffix} from '@angular/material/form-field';
import {MatIcon} from '@angular/material/icon';
import {FormControl, FormGroup, ReactiveFormsModule} from '@angular/forms';
import {
  MatDatepicker, MatDatepickerInput,
  MatDatepickerToggle,
  MatDateRangeInput,
  MatDateRangePicker,
  MatEndDate,
  MatStartDate
} from '@angular/material/datepicker';
import {provideNativeDateAdapter} from '@angular/material/core';
import {MatInput} from '@angular/material/input';
import {MatDialogActions, MatDialogContent} from '@angular/material/dialog';
import {LegendPosition, NgxChartsModule} from '@swimlane/ngx-charts';
import {
  MatAccordion,
  MatExpansionPanel,
  MatExpansionPanelHeader,
  MatExpansionPanelTitle
} from '@angular/material/expansion';

@Component({
  selector: 'app-user-training-records-tab',
  imports: [
    NgxChartsModule,
    MatSuffix,
    MatButton,
    MatDatepickerToggle,
    ReactiveFormsModule,
    MatLabel,
    MatFormField,
    MatExpansionPanelHeader,
    MatButton,
    MatLabel,
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
    MatIcon,
    MatHint,
    MatError,
    MatDateRangePicker,
    MatDatepickerToggle,
    ReactiveFormsModule,
    MatStartDate,
    MatEndDate,
    MatDateRangeInput,
    MatExpansionPanel,
    MatExpansionPanelTitle,
    MatAccordion
  ],
  providers: [provideNativeDateAdapter()],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './user-training-records-tab.component.html',
  styleUrl: './user-training-records-tab.component.scss'
})
export class UserTrainingRecordsTabComponent implements OnInit, AfterViewInit{
  userId = input.required<number>();
  exerciseId = input.required<number[]>();
  chartView = signal<boolean>(false)
  columns: string[] = ['exerciseName','weightLifted', 'repetitionsMade', 'recordDate','actions']
  recordsForTable: TrainingRecordContent[] = []
  recordsForChart: TrainingRecordContent[][] = []
  trainingRecordService = inject(TrainingRecordService)
  dataSource:MatTableDataSource<TrainingRecordContent> = new MatTableDataSource()
  paginator = viewChild.required<MatPaginator>(MatPaginator)
  sort = viewChild.required<MatSort>(MatSort)
  dateRangeForm = new FormGroup({
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null),
  })
  repetitionsChartData: object[] = []
  weightsChartData: object[] = []

  ngOnInit() {
    this.recordsForTable = []
    this.recordsForChart = []
    this.exerciseId().forEach((exerciseId) => {
      this.trainingRecordService.getTrainingRecordsByUserIdAndExerciseId(this.userId() as number, exerciseId as number).subscribe({
        next: (res) => {
          this.recordsForTable = this.recordsForTable.concat(res)
          this.recordsForChart.push(res)
          this.dataSource = new MatTableDataSource(this.recordsForTable);
          this.initChart();
        }
      })
    })
  }

  ngAfterViewInit() {
    this.refreshRecords()
  }

  dateRangeFilter() {
    return (data: TrainingRecordContent, filter: string): boolean => {
      if (!this.dateRangeForm.value.start || !this.dateRangeForm.value.end) return true;
      const recordDate = new Date(data.recordDate);
      recordDate.setMinutes(recordDate.getTimezoneOffset());
      return recordDate >= this.dateRangeForm.value.start && recordDate <= this.dateRangeForm.value.end;
    };
  }
  dateRangeFilterChart() {
    return (data: TrainingRecordContent): boolean => {
      if (!this.dateRangeForm.value.start || !this.dateRangeForm.value.end) return true;
      const recordDate = new Date(data.recordDate)
      recordDate.setMinutes(recordDate.getTimezoneOffset());
      return recordDate >= this.dateRangeForm.value.start && recordDate <= this.dateRangeForm.value.end;
    };
  }
  applyFilter() {
    const filterValue = `${this.dateRangeForm.value.start}-${this.dateRangeForm.value.end}`;;
    this.dataSource.filterPredicate = this.dateRangeFilter()
    this.initChart()
    this.dataSource.filter = filterValue
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  refreshRecords(){
    this.recordsForTable = []
    this.recordsForChart = []
    this.exerciseId().forEach((exerciseId) => {
      this.trainingRecordService.getTrainingRecordsByUserIdAndExerciseId(this.userId() as number, exerciseId as number).subscribe({
        next: (res) => {
          this.recordsForTable = this.recordsForTable.concat(res)
          this.recordsForChart.push(res)
          this.initChart();
          this.dataSource.data = this.recordsForTable;
          if (!this.chartView()) {
            this.dataSource.sort = this.sort();
            this.dataSource.paginator = this.paginator();
          }

        }
      })
    })
  }
  deleteRecord(id:number){
    this.trainingRecordService.deleteRecordById(id).subscribe({
      next: (res) => {
        this.refreshRecords()
      }
    })
  }

  initChart() {
    this.repetitionsChartData = this.toNgxChartFormatRepetitions(this.recordsForChart)
    this.weightsChartData = this.toNgxChartFormatWeights(this.recordsForChart)
  }

  changeView() {
    this.chartView.set(!this.chartView())
    this.refreshRecords()
  }
  toNgxChartFormatRepetitions(trainingData: TrainingRecordContent[][]) {
    let result: any[] = [];
    trainingData.forEach(recList => {
      result.push({
        name: recList[0].exercise.exerciseName,
        series: recList.filter(this.dateRangeFilterChart()).map(rec => ({
          name: rec.recordDate,
          value: [rec.repetitionsMade],
        }))
      })
    })
    return result;
  }
  toNgxChartFormatWeights(trainingData: TrainingRecordContent[][]) {
    let result: any[] = [];
    trainingData.forEach(recList => {
      result.push({
        name: recList[0].exercise.exerciseName,
        series: recList.filter(this.dateRangeFilterChart()).map(rec => ({
          name: rec.recordDate,
          value: [rec.weightLifted],
        }))
      })
    })
    return result;
  }


  protected readonly LegendPosition = LegendPosition;
}
