export interface TrainingPlanModel {
  id: number
  objective: string
}
export const DAYS_OF_WEEK_ORDER: Record<string, number> = {
  "monday": 1,
  "tuesday": 2,
  "wednesday": 3,
  "thursday": 4,
  "friday": 5,
  "saturday": 6,
  "sunday": 7
};

export interface RoutineModel {
  id: number
  routineName: string
}

export interface TrainingPlanContent {
  trainingPlanId: number
  objective: string
  routineResponses: TrainingPlanRoutineContent[]
}

export interface TrainingPlanRoutineContent {
  id: number
  trainingPlanId: number
  routineId: number
  routineName: string
  routineWeekDay: string
  routineExerciseContent: RoutineExerciseContent[]
}

export interface RoutineExerciseContent {
  id: number
  routineId: number
  exerciseId: number
  exerciseName: string
  effort: number
  exerciseSetContent: ExerciseSetContent[]
}

export interface ExerciseSetContent {
  id: number
  exerciseId: number
  setId: number
  fatigue: number
  repetitions: number
  weight: number
}
export interface UserTrainingPlanTrainingPlanCombined {
  id: number
  userId: number
  trainingPlanId: number
  objective: string
  assignedDate: string
}
export interface UserTrainingPlanData {
  userId: number
  trainingPlanId: number
  assignedDate: string
}
export interface CreateTrainingPlanData {
  objective: string
}
export interface TrainingPlanData {
  id: number
  objective: string
}
export interface CreateRoutineData {
  routineName: string
}

export interface AddRoutineToTrainingPlanData {
  trainingPlanId: number
}

export interface TrainingPlanRoutineData {
  routineId: number
  trainingPlanId: number
  routineWeekDay: string
}

export interface CreateExerciseData {
  exerciseName: string
}
export interface AddExerciseToRoutineData {
  routineId: number
}
export interface ExerciseModel {
  id: number
  exerciseName: string
}

export interface RoutineExerciseData {
  routineId: number
  exerciseId: number
  effort: number
}

export interface SetModel {
  id: number
  repetitions: number
  weight: number
}
export interface ExerciseSetData {
  exerciseId: number
  setId: number
  fatigue: number
}
export interface SetActionsData {
  exerciseId: number
}

export interface SetData {
  repetitions: number
  weight: number
}

export interface AddTrainingPlanData {
  userId: number
}
