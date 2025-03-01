export interface RoutineModel {
  id: number
  routineName: string
}

export interface UserRoutineRoutineCombined {
  id: number
  userId: number
  routineId: number
  routineName: string
  targetDate: string
}
