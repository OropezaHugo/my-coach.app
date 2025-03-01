export interface TrainingPlanModel {
  id: number
  objective: string
}

export interface UserTrainingPlanTrainingPlanCombined {
  id: number
  userId: number
  trainingPlanId: number
  objective: string
  assignedDate: string
}
