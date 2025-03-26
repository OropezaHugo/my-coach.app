export interface ISAKMeasuresModel {
  // Skinfolds (mm)
  tricepsMm: number;
  subscapularMm: number;
  bicepsMm: number;
  iliacCrestMm: number;
  supraespinalMm: number;
  abdominalMm: number;
  frontThighMm: number;
  medialCalfMm: number;
  // Perimeters (cm)
  relaxedArmCm: number;
  flexedArmCm: number;
  waistCm: number;
  hipCm: number;
  midThighCm: number;
  calfCm: number;
  // Bone Diameters (cm)
  wristDiameterCm: number;
  elbowDiameterCm: number;
  kneeDiameterCm: number;
  // Body Measurements
  weightKg: number;
  totalHeightMts: number;
  wingspanCm: number;
  footLengthCm: number;

  measureDate: string;
  userId: number;
  id: number;
}

export interface ISAKMeasuresData {
  // Skinfolds (mm)
  tricepsMm: number;
  subscapularMm: number;
  bicepsMm: number;
  iliacCrestMm: number;
  supraespinalMm: number;
  abdominalMm: number;
  frontThighMm: number;
  medialCalfMm: number;
  // Perimeters (cm)
  relaxedArmCm: number;
  flexedArmCm: number;
  waistCm: number;
  hipCm: number;
  midThighCm: number;
  calfCm: number;
  // Bone Diameters (cm)
  wristDiameterCm: number;
  elbowDiameterCm: number;
  kneeDiameterCm: number;
  // Body Measurements
  weightKg: number;
  totalHeightMts: number;
  wingspanCm: number;
  footLengthCm: number;

  measureDate: string;
  userId: number;
}

export function transformMeasuresToSkinFoldsSeries(measures: ISAKMeasuresModel[]): object[] {
  let measureSeries: object[] = [
    createSeries(measures, 'tricepsMm', 'Triceps (mm)'),
    createSeries(measures, 'subscapularMm', 'Subscapular (mm)'),
    createSeries(measures, 'bicepsMm', 'Biceps (mm)'),
    createSeries(measures, 'iliacCrestMm', 'Iliac Crest (mm)'),
    createSeries(measures, 'supraespinalMm', 'Supraespinal (mm)'),
    createSeries(measures, 'abdominalMm', 'Abdominal (mm)'),
    createSeries(measures, 'frontThighMm', 'Front Thigh (mm)'),
    createSeries(measures, 'medialCalfMm', 'Medial Calf (mm)')
  ];

  return measureSeries;
}
export function transformMeasuresToPerimetersSeries(measures: ISAKMeasuresModel[]): object[] {
  let measureSeries: object[] = [
    createSeries(measures, 'relaxedArmCm', 'Relaxed Arm (cm)'),
    createSeries(measures, 'flexedArmCm', 'Flexed Arm (cm)'),
    createSeries(measures, 'waistCm', 'Waist (cm)'),
    createSeries(measures, 'hipCm', 'Hip (cm)'),
    createSeries(measures, 'midThighCm', 'Mid Thigh (cm)'),
    createSeries(measures, 'calfCm', 'Calf (cm)'),
  ];

  return measureSeries;
}
export function transformMeasuresToDiametersSeries(measures: ISAKMeasuresModel[]): object[] {
  let measureSeries: object[] = [
    createSeries(measures, 'wristDiameterCm', 'Wrist Diameter (cm)'),
    createSeries(measures, 'elbowDiameterCm', 'Elbow Diameter (cm)'),
    createSeries(measures, 'kneeDiameterCm', 'Knee Diameter (cm)'),
  ];

  return measureSeries;
}
export function transformMeasuresToLengthMeasuresSeries(measures: ISAKMeasuresModel[]): object[] {

  let measureSeries: object[] = [
    createSeries(measures, 'wingspanCm', 'Wingspan (cm)'),
    createSeries(measures, 'footLengthCm', 'Foot Length (cm)'),
  ];

  return measureSeries;
}

export function transformMeasuresToWeightMeasuresSeries(measures: ISAKMeasuresModel[]): object[] {

  let measureSeries: object[] = [
    createSeries(measures, 'weightKg', 'Weight (kg)'),
  ];

  return measureSeries;
}

export function transformMeasuresToHeightMeasuresSeries(measures: ISAKMeasuresModel[]): object[] {

  let measureSeries: object[] = [
    createSeries(measures, 'totalHeightMts', 'Height (m)'),
  ];

  return measureSeries;
}

function createSeries(
  measures: ISAKMeasuresModel[],
  property: keyof ISAKMeasuresModel,
  name: string
): object {
  return {
    name,
    series: measures.map(measure => ({
      name: measure.measureDate,
      value: measure[property] as number,
    })).filter(item => item.value != null)
  };
}

