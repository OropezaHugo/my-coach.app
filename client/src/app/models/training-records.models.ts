import {ExerciseModel} from './training-plan.models';

export interface TrainingRecordData {
  weightLifted: number;
  repetitionsMade: number;
  recordDate: string;
  userId: number;
  exerciseId: number;
}
export interface TrainingRecordModel {
  id: number;
  weightLifted: number;
  repetitionsMade: number;
  recordDate: string;
  userId: number;
  exerciseId: number;
}
export interface ExerciseBasicData {
  id: number;
  exerciseName: string;
}
export interface TrainingRecordContent {
  weightLifted: number;
  repetitionsMade: number;
  recordDate: string;
  userId: number;
  exercise: ExerciseModel;
}
export interface AddRecordDialogDada {
  userId: number;
}
