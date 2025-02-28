export interface UserDiet {
  id: number
  userId: number
  dietId: number
  dietName: string
  waterAmount: number
  assignedDate: string
}

export interface FoodGroupModel {
  id: number
  foodGroupId: number
  foodGroupName: string
  dietId: number
  foodGroupFoodInfos: FoodGroupFoodModel[]
}
export interface FoodGroupFoodModel {
  id: number
  foodId: number
  foodName: string
  foodAmount: number
  foodGroupId: number
}
export interface FoodModel {
  id: number
  foodName: string
}

export interface AddFoodData {
  foodGroupId: number
}

export interface FoodGroupFoodData {
  foodGroupId: number
  foodId: number
  foodAmount: number
}
