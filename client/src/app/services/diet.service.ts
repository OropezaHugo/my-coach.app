import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient} from '@angular/common/http';
import {
  FoodGroupFoodData,
  FoodGroupAndContentModel,
  FoodModel,
  UserDietCombined,
  FoodGroupCreationData, FoodGroupData, DietFoodGroupData, CreateDietData, DietData, UserDietData
} from '../models/diet.models';

@Injectable({
  providedIn: 'root'
})
export class DietService {
  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)

  //diet
  getAllDiets(){
    return this.http.get<DietData[]>(`${this.baseUrl}/diet/`)
  }
  getDietNames() {
    return this.http.get<string[]>(`${this.baseUrl}/diet/names`)
  }
  getDietsByUserId(id: number){
    return this.http.get<UserDietCombined[]>(`${this.baseUrl}/diet/user/${id}`)
  }

  createDiet(diet: CreateDietData){
    return this.http.post<DietData>(`${this.baseUrl}/diet`,diet)
  }

  addDietToUserDiets(diet: UserDietData){
    return this.http.post<boolean>(`${this.baseUrl}/userdiet`,diet)
  }

  //diet-foodGroup relation
  deleteFoodGroupFromDietById(id: number){
    return this.http.delete(`${this.baseUrl}/dietfoodgroup/${id}`)
  }

  updateDietFoodGroupById(id: number, dietFoodGroupData: DietFoodGroupData){
    return this.http.put<boolean>(`${this.baseUrl}/dietfoodgroup/${id}`, dietFoodGroupData)
  }


  //foodGroups
  getFoodGroupsByDietId(id: number){
    return this.http.get<FoodGroupAndContentModel[]>(`${this.baseUrl}/foodgroup/diet/${id}`)
  }
  getAllFoodGroups(){
    return this.http.get<FoodGroupData[]>(`${this.baseUrl}/foodgroup`)
  }
  getFoodGroupNames() {
    return this.http.get<string[]>(`${this.baseUrl}/foodgroup/names`)
  }
  createFoodGroup(foodGroup: FoodGroupCreationData){
    return this.http.post<FoodGroupData>(`${this.baseUrl}/foodgroup`, foodGroup)
  }

  addFoodGroupToDiet(dietFoodGroup: DietFoodGroupData){
    return this.http.post<boolean>(`${this.baseUrl}/dietfoodgroup`, dietFoodGroup)
  }

  //food
  getAllFoods() {
    return this.http.get<FoodModel[]>(`${this.baseUrl}/food`)
  }

  getFoodById(id: number){
    return this.http.get<FoodModel>(`${this.baseUrl}/food/${id}`)
  }
  addFoodToFoodGroup(foodGroupFoodData: FoodGroupFoodData){
    return this.http.post<boolean>(`${this.baseUrl}/foodgroupfood`, foodGroupFoodData)
  }

  //food-foodGroup relation
  deleteFoodGroupFoodById(id: number){
    return this.http.delete<boolean>(`${this.baseUrl}/foodgroupfood/${id}`)
  }
  updateFoodGroupFoodById(id: number, foodGroupFoodData: FoodGroupFoodData){
    return this.http.put<boolean>(`${this.baseUrl}/foodgroupfood/${id}`, foodGroupFoodData)
  }
}
