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
