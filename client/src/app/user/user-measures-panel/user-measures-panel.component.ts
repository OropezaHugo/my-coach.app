import {ChangeDetectorRef, Component, inject, input, OnInit, PLATFORM_ID, signal} from '@angular/core';
import {MeasuresService} from '../../services/measures.service';
import {MatButton} from '@angular/material/button';
import {ISAKMeasuresModel} from '../../models/measure.models';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {UserMeasuresTableComponent} from '../user-measures-table/user-measures-table.component';
import {UIChart} from 'primeng/chart';
import {isPlatformBrowser} from '@angular/common';
import {
  MatAccordion,
  MatExpansionPanel,
  MatExpansionPanelHeader,
  MatExpansionPanelTitle
} from '@angular/material/expansion';

@Component({
  selector: 'app-user-measures-panel',
  imports: [
    MatButton,
    MatLabel,
    MatFormField,
    MatInput,
    MatExpansionPanelTitle,
    ReactiveFormsModule,
    UserMeasuresTableComponent,
    UIChart,
    MatExpansionPanelHeader,
    MatExpansionPanel,
    MatAccordion
  ],
  templateUrl: './user-measures-panel.component.html',
  styleUrl: './user-measures-panel.component.scss'
})
export class UserMeasuresPanelComponent implements OnInit {
  userId = input.required<number>();
  editable = input.required<boolean>()
  editing = signal<boolean>(false)
  measuresService = inject(MeasuresService)
  userMeasures: ISAKMeasuresModel[] = []
  addMeasuresForm = new FormGroup({
    tricepsMmSkinfold: new FormControl<number>(0, [Validators.required]),
    subscapularMmSkinfold: new FormControl<number>(0, [Validators.required]),
    bicepsMmSkinfold: new FormControl<number>(0, [Validators.required]),
    iliacMmSkinfold: new FormControl<number>(0, [Validators.required]),
    supraespinalMmSkinfold: new FormControl<number>(0, [Validators.required]),
    abdominalMmSkinfold: new FormControl<number>(0, [Validators.required]),
    frontThighMmSkinfold: new FormControl<number>(0, [Validators.required]),
    medialCalfMmSkinfold: new FormControl<number>(0, [Validators.required]),

    relaxedArmCmPerimeter: new FormControl<number>(0, [Validators.required]),
    flexedArmCmPerimeter: new FormControl<number>(0, [Validators.required]),
    waistCmPerimeter: new FormControl<number>(0, [Validators.required]),
    hipCmPerimeter: new FormControl<number>(0, [Validators.required]),
    midThighCmPerimeter: new FormControl<number>(0, [Validators.required]),
    calfCmPerimeter: new FormControl<number>(0, [Validators.required]),

    wristCmDiameter: new FormControl<number>(0, [Validators.required]),
    elbowCmDiameter: new FormControl<number>(0, [Validators.required]),
    kneeCmDiameter: new FormControl<number>(0, [Validators.required]),

    weightKgMeasure: new FormControl<number>(0, [Validators.required]),
    totalHeightMtsMeasure: new FormControl<number>(0, [Validators.required]),
    wingspanCmMeasure: new FormControl<number>(0, [Validators.required]),
    footLengthCmMeasure: new FormControl<number>(0, [Validators.required]),
  })
  otherMeasuresData: any;
  skinFoldsData: any;
  perimetersData: any;
  diametersData: any;
  chartView = signal<boolean>(false);
  options: any;
  platformId = inject(PLATFORM_ID);
  cd = inject(ChangeDetectorRef)

  ngOnInit() {
    this.measuresService.getMeasuresByUserId(this.userId() as number).subscribe({
      next: data => {
        this.userMeasures = data
        this.initChart();
      }
    })
  }

  entryEditingMode(){

    this.measuresService.getLastMeasureIn3MonthsByUserId(this.userId() as number).subscribe({
      next: data => {
        this.addMeasuresForm.controls.tricepsMmSkinfold.setValue(data.tricepsMm);
        this.addMeasuresForm.controls.subscapularMmSkinfold.setValue(data.subscapularMm);
        this.addMeasuresForm.controls.bicepsMmSkinfold.setValue(data.bicepsMm);
        this.addMeasuresForm.controls.iliacMmSkinfold.setValue(data.iliacCrestMm);
        this.addMeasuresForm.controls.supraespinalMmSkinfold.setValue(data.supraespinalMm);
        this.addMeasuresForm.controls.abdominalMmSkinfold.setValue(data.abdominalMm);
        this.addMeasuresForm.controls.frontThighMmSkinfold.setValue(data.frontThighMm);
        this.addMeasuresForm.controls.medialCalfMmSkinfold.setValue(data.medialCalfMm);

        this.addMeasuresForm.controls.relaxedArmCmPerimeter.setValue(data.relaxedArmCm);
        this.addMeasuresForm.controls.flexedArmCmPerimeter.setValue(data.flexedArmCm);
        this.addMeasuresForm.controls.waistCmPerimeter.setValue(data.waistCm);
        this.addMeasuresForm.controls.hipCmPerimeter.setValue(data.hipCm);
        this.addMeasuresForm.controls.midThighCmPerimeter.setValue(data.midThighCm);
        this.addMeasuresForm.controls.calfCmPerimeter.setValue(data.calfCm);

        this.addMeasuresForm.controls.wristCmDiameter.setValue(data.wristDiameterCm);
        this.addMeasuresForm.controls.elbowCmDiameter.setValue(data.elbowDiameterCm);
        this.addMeasuresForm.controls.kneeCmDiameter.setValue(data.kneeDiameterCm);

        this.addMeasuresForm.controls.weightKgMeasure.setValue(data.weightKg);
        this.addMeasuresForm.controls.totalHeightMtsMeasure.setValue(data.totalHeightMts);
        this.addMeasuresForm.controls.wingspanCmMeasure.setValue(data.wingspanCm);
        this.addMeasuresForm.controls.footLengthCmMeasure.setValue(data.footLengthCm);
        this.editing.set(true)
      },
      error: err => {
        if (err.status === 404) {
          this.editing.set(true)
        }
      }
    })
  }
  createMeasureReport() {
    if (Object.values(this.addMeasuresForm.value).every(value => value !== null && value !== undefined)
      && this.addMeasuresForm.valid) {
      this.measuresService.createISAKMeasure({
        userId: this.userId(),
        abdominalMm: this.addMeasuresForm.value.abdominalMmSkinfold!,
        bicepsMm: this.addMeasuresForm.value.bicepsMmSkinfold!,
        calfCm: this.addMeasuresForm.value.calfCmPerimeter!,
        elbowDiameterCm: this.addMeasuresForm.value.elbowCmDiameter!,
        flexedArmCm: this.addMeasuresForm.value.flexedArmCmPerimeter!,
        footLengthCm: this.addMeasuresForm.value.footLengthCmMeasure!,
        frontThighMm: this.addMeasuresForm.value.frontThighMmSkinfold!,
        hipCm: this.addMeasuresForm.value.hipCmPerimeter!,
        measureDate: new Date().toISOString().split('T')[0],
        iliacCrestMm: this.addMeasuresForm.value.iliacMmSkinfold!,
        kneeDiameterCm: this.addMeasuresForm.value.kneeCmDiameter!,
        medialCalfMm: this.addMeasuresForm.value.medialCalfMmSkinfold!,
        midThighCm: this.addMeasuresForm.value.midThighCmPerimeter!,
        relaxedArmCm: this.addMeasuresForm.value.relaxedArmCmPerimeter!,
        subscapularMm: this.addMeasuresForm.value.subscapularMmSkinfold!,
        supraespinalMm: this.addMeasuresForm.value.supraespinalMmSkinfold!,
        totalHeightMts: this.addMeasuresForm.value.totalHeightMtsMeasure!,
        tricepsMm: this.addMeasuresForm.value.tricepsMmSkinfold!,
        waistCm: this.addMeasuresForm.value.waistCmPerimeter!,
        weightKg: this.addMeasuresForm.value.weightKgMeasure!,
        wingspanCm: this.addMeasuresForm.value.wingspanCmMeasure!,
        wristDiameterCm: this.addMeasuresForm.value.wristCmDiameter!
      }).subscribe({
        next: value => {
          this.measuresService.getMeasuresByUserId(this.userId() as number).subscribe({
            next: data => {
              this.userMeasures = data
              this.initChart()
              this.editing.set(false)
            }
          })
        }
      })
    }
  }

  initChart() {
    if (isPlatformBrowser(this.platformId)) {
      const documentStyle = getComputedStyle(document.documentElement);
      const textColor = 'white'
      const textColorSecondary = 'white'
      const surfaceBorder = 'white'

      this.otherMeasuresData = {
        labels: this.userMeasures.map(value => value.measureDate),
        datasets: [
          {
            label: 'weight (kg)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.weightKg)
          },
          {
            label: 'height (mts)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-gray-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.totalHeightMts)
          },
          {
            label: 'wingspan (cm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-gray-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.wingspanCm)
          },
          {
            label: 'footLength (cm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-gray-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.footLengthCm)
          }
        ]
      };

      this.skinFoldsData = {
        labels: this.userMeasures.map(value => value.measureDate),
        datasets: [
          {
            label: 'triceps (mm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.tricepsMm)
          },
          {
            label: 'sub scapular (mm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.subscapularMm)
          },
          {
            label: 'biceps (mm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.bicepsMm)
          },
          {
            label: 'iliac (mm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.iliacCrestMm)
          },
          {
            label: 'supra spinal (mm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.supraespinalMm)
          },
          {
            label: 'abdominal (mm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.abdominalMm)
          },
          {
            label: 'front thigh (mm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.frontThighMm)
          },
          {
            label: 'medial calf (mm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.medialCalfMm)
          }
        ]
      };
      this.perimetersData = {
        labels: this.userMeasures.map(value => value.measureDate),
        datasets: [
          {
            label: 'relaxed arm (cm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.relaxedArmCm)
          },
          {
            label: 'flexed arm (cm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.flexedArmCm)
          },
          {
            label: 'waist (cm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.waistCm)
          },
          {
            label: 'hip (cm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.hipCm)
          },
          {
            label: 'mid thigh (cm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.midThighCm)
          },
          {
            label: 'calf (cm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.calfCm)
          },
        ]
      }
      this.diametersData = {
        labels: this.userMeasures.map(value => value.measureDate),
        datasets: [
          {
            label: 'wrist (cm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.wristDiameterCm)
          },
          {
            label: 'elbow (cm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.elbowDiameterCm)
          },
          {
            label: 'knee (cm)',
            fill: false,
            borderColor: documentStyle.getPropertyValue('--p-cyan-500'),
            yAxisID: 'y',
            tension: 0,
            data: this.userMeasures.map(value => value.kneeDiameterCm)
          },
        ]
      }
      this.options = {
        stacked: false,
        maintainAspectRatio: false,
        aspectRatio: 0.5,
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
