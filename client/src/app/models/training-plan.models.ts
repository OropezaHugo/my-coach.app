export interface TrainingPlanModel {
  id: number
  objective: string
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
