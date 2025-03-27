import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  inject,
  input,
  OnInit,
  PLATFORM_ID,
  signal
} from '@angular/core';
import {MeasuresService} from '../../services/measures.service';
import {MatButton, MatIconButton} from '@angular/material/button';
import {
  ISAKMeasuresModel,
  transformMeasuresToDiametersSeries,
  transformMeasuresToHeightMeasuresSeries,
  transformMeasuresToLengthMeasuresSeries,
  transformMeasuresToPerimetersSeries,
  transformMeasuresToSkinFoldsSeries,
  transformMeasuresToWeightMeasuresSeries
} from '../../models/measure.models';
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
import {LegendPosition, NgxChartsModule} from '@swimlane/ngx-charts';
import {provideNativeDateAdapter} from '@angular/material/core';
import {MatIcon} from '@angular/material/icon';

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
    MatAccordion,
    NgxChartsModule,
    MatIcon,
    MatIconButton
  ],
  templateUrl: './user-measures-panel.component.html',
  styleUrl: './user-measures-panel.component.scss'
})
export class UserMeasuresPanelComponent implements OnInit {
  userId = input.required<number>();
  editable = input.required<boolean>()
  creating = signal<boolean>(false)
  editing = signal<boolean>(false)
  measureEditId = 0
  measuresService = inject(MeasuresService)
  skinFoldsChartData: object[] = []
  perimetersChartData: object[] = []
  diametersChartData: object[] = []
  lengthMeasuresChartData: object[] = []
  weightMeasuresChartData: object[] = []
  heightMeasuresChartData: object[] = []
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
  chartView = signal<boolean>(false);

  ngOnInit() {
    this.measuresService.getMeasuresByUserId(this.userId() as number).subscribe({
      next: data => {
        this.userMeasures = data
        this.initChart();

      }
    })
  }

  entryCreatingMode(){

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
        this.creating.set(true)
      },
      error: err => {
        if (err.status === 404) {
          this.creating.set(true)
        }
      }
    })
  }
  entryEditingMode(data: ISAKMeasuresModel){
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
    this.measureEditId = data.id;
  }
  updateMeasureReport() {
    if (Object.values(this.addMeasuresForm.value).every(value => value !== null && value !== undefined)
      && this.addMeasuresForm.valid && this.measureEditId > 0) {
      this.measuresService.updateISAKMeasure(this.measureEditId, {
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
              this.measureEditId = 0
              this.initChart()
              this.editing.set(false)
            }
          })
        }
      })
    }
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
              this.creating.set(false)
            }
          })
        }
      })
    }
  }

  initChart() {
    this.skinFoldsChartData = transformMeasuresToSkinFoldsSeries(this.userMeasures)
    this.perimetersChartData = transformMeasuresToPerimetersSeries(this.userMeasures)
    this.diametersChartData = transformMeasuresToDiametersSeries(this.userMeasures)
    this.lengthMeasuresChartData = transformMeasuresToLengthMeasuresSeries(this.userMeasures)
    this.weightMeasuresChartData = transformMeasuresToWeightMeasuresSeries(this.userMeasures)
    this.heightMeasuresChartData = transformMeasuresToHeightMeasuresSeries(this.userMeasures)
  }

  protected readonly LegendPosition = LegendPosition;

}
