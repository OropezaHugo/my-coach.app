using System.Text.Json;
using Core.Entities.DietEntities;
using Core.Entities.ExerciseEntities;

namespace Infrastructure.Data;

public static class CoachAppSeed
{
    public static async Task SeedAsync(CoachAppContext coachAppContext)
    {
        // Seed Diets
        if (!coachAppContext.Diets.Any())
        {
            var dietData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/DietData.json");
            var diets = JsonSerializer.Deserialize<List<Diet>>(dietData);
            if (diets != null)
            {
                coachAppContext.Diets.AddRange(diets);
                await coachAppContext.SaveChangesAsync();
            }
        }
        
        // Seed Foods
        if (!coachAppContext.Foods.Any())
        {
            var foodData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/FoodData.json");
            var foods = JsonSerializer.Deserialize<List<Food>>(foodData);
            if (foods != null)
            {
                coachAppContext.Foods.AddRange(foods);
                await coachAppContext.SaveChangesAsync();
            }
        }
        // Seed FoodGroups
        if (!coachAppContext.FoodGroups.Any())
        {
            var foodGroupData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/FoodGroupData.json");
            var foodGroups = JsonSerializer.Deserialize<List<FoodGroup>>(foodGroupData);
            if (foodGroups != null)
            {
                coachAppContext.FoodGroups.AddRange(foodGroups);
                await coachAppContext.SaveChangesAsync();
            }
        }

        // Seed DietFoodGroups
        if (!coachAppContext.DietFoodGroups.Any())
        {
            var dietFoodGroupData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/DietFoodGroupData.json");
            var dietFoodGroups = JsonSerializer.Deserialize<List<DietFoodGroup>>(dietFoodGroupData);
            if (dietFoodGroups != null)
            {
                coachAppContext.DietFoodGroups.AddRange(dietFoodGroups);
                await coachAppContext.SaveChangesAsync();
            }
        }

        
        
        // Seed FoodGroupFoods
        if (!coachAppContext.FoodGroupFoods.Any())
        {
            var foodGroupFoodData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/FoodGroupFoodData.json");
            var foodGroupFoods = JsonSerializer.Deserialize<List<FoodGroupFood>>(foodGroupFoodData);
            if (foodGroupFoods != null)
            {
                coachAppContext.FoodGroupFoods.AddRange(foodGroupFoods);
                await coachAppContext.SaveChangesAsync();
            }
        }
        
        // Seed Exercises
        if (!coachAppContext.Exercises.Any())
        {
            var exerciseData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/ExerciseData.json");
            var exercises = JsonSerializer.Deserialize<List<Exercise>>(exerciseData);
            if (exercises != null)
            {
                coachAppContext.Exercises.AddRange(exercises);
                await coachAppContext.SaveChangesAsync();
            }
        }

        // Seed Sets
        if (!coachAppContext.Sets.Any())
        {
            var setData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/SetData.json");
            var sets = JsonSerializer.Deserialize<List<Set>>(setData);
            if (sets != null)
            {
                coachAppContext.Sets.AddRange(sets);
                await coachAppContext.SaveChangesAsync();
            }
        }

        // Seed ExerciseSets
        if (!coachAppContext.ExerciseSets.Any())
        {
            var exerciseSetData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/ExerciseSetData.json");
            var exerciseSets = JsonSerializer.Deserialize<List<ExerciseSet>>(exerciseSetData);
            if (exerciseSets != null)
            {
                coachAppContext.ExerciseSets.AddRange(exerciseSets);
                await coachAppContext.SaveChangesAsync();
            }
        }

        // Seed Routines
        if (!coachAppContext.Routines.Any())
        {
            var routineData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/RoutineData.json");
            var routines = JsonSerializer.Deserialize<List<Routine>>(routineData);
            if (routines != null)
            {
                coachAppContext.Routines.AddRange(routines);
                await coachAppContext.SaveChangesAsync();
            }
        }

        // Seed RoutineExercises
        if (!coachAppContext.RoutineExercises.Any())
        {
            var routineExerciseData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/RoutineExerciseData.json");
            var routineExercises = JsonSerializer.Deserialize<List<RoutineExercise>>(routineExerciseData);
            if (routineExercises != null)
            {
                coachAppContext.RoutineExercises.AddRange(routineExercises);
                await coachAppContext.SaveChangesAsync();
            }
        }
    }
}