export interface UserDietCombined {
  id: number
  userId: number
  dietId: number
  dietName: string
  waterAmount: number
  assignedDate: string
}
export interface UserDietData {
  userId: number
  dietId: number
  assignedDate: string
}
export interface CreateDietData {
  dietName: string
  waterAmount: number
}
export interface AddDietData {
  userId: number
}

export interface DietData {
  id: number
  dietName: string
  waterAmount: number
}

export interface FoodGroupAndContentModel {
  id: number
  foodGroupId: number
  foodGroupName: string
  foodGroupTime: string
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

export interface FoodGroupCreationData {
  foodGroupName: string
}

export interface FoodGroupData {
  id: number
  foodGroupName: string
}

export interface DietFoodGroupData {
  foodGroupId: number
  dietId: number
  foodGroupTime: string
}

export interface AddFoodGroupData {
  dietId: number
}
