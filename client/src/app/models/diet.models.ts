export interface UserDietDietCombined {
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
export interface AddDietDataToUserDiets {
  userId: number
}

export interface DietModel {
  id: number
  dietName: string
  waterAmount: number
}

export interface DietContent {
  dietId: number
  dietName: string
  waterAmount: number
  dietFoodGroupInfos: FoodGroupAndContentModel[]
}
export interface FoodGroupAndContentModel {
  id: number
  foodGroupId: number
  foodGroupName: string
  foodGroupTime: string
  dietId: number
  foodGroupFoodInfos: FoodGroupFoodCombinedModel[]
}
export interface FoodGroupFoodCombinedModel {
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

export interface AddFoodToFoodGroupData {
  foodGroupId: number
}

export interface FoodGroupFoodData {
  foodGroupId: number
  foodId: number
  foodAmount: number
}

export interface CreateFoodGroupData {
  foodGroupName: string
}

export interface FoodGroupModel {
  id: number
  foodGroupName: string
}

export interface DietFoodGroupData {
  foodGroupId: number
  dietId: number
  foodGroupTime: string
}

export interface AddFoodGroupToDietData {
  dietId: number
}
