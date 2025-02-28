import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient} from '@angular/common/http';
import {FoodGroupFoodData, FoodGroupModel, FoodModel, UserDiet} from '../models/diet.models';

@Injectable({
  providedIn: 'root'
})
export class DietService {
  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)

  getDietsByUserId(id: number){
    return this.http.get<UserDiet[]>(`${this.baseUrl}/diet/user/${id}`)
  }
  getFoodGroupsByDietId(id: number){
    return this.http.get<FoodGroupModel[]>(`${this.baseUrl}/foodgroup/diet/${id}`)
  }
  getAllFoods() {
    return this.http.get<FoodModel[]>(`${this.baseUrl}/food`)
  }

  getFoodById(id: number){
    return this.http.get<FoodModel>(`${this.baseUrl}/food/${id}`)
  }
  addFoodToFoodGroup(foodGroupFoodData: FoodGroupFoodData){
    return this.http.post<boolean>(`${this.baseUrl}/foodgroupfood`, foodGroupFoodData)
  }
  deleteFoodGroupFoodById(id: number){
    return this.http.delete<boolean>(`${this.baseUrl}/foodgroupfood/${id}`)
  }
  updateFoodGroupFoodById(id: number, foodGroupFoodData: FoodGroupFoodData){
    return this.http.put<boolean>(`${this.baseUrl}/foodgroupfood/${id}`, foodGroupFoodData)
  }
}
