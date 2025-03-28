using System.Text.Json;
using Core.Entities;
using Core.Entities.DietEntities;
using Core.Entities.GamificationEntities;
using Core.Entities.TrainingPlanEntities;

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
        
        //Seed TrainingPlans
        if (!coachAppContext.TrainingPlans.Any())
        {
            var routineExerciseData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/TrainingPlansData.json");
            var routineExercises = JsonSerializer.Deserialize<List<TrainingPlan>>(routineExerciseData);
            if (routineExercises != null)
            {
                coachAppContext.TrainingPlans.AddRange(routineExercises);
                await coachAppContext.SaveChangesAsync();
            }
        }
        
        //Seed TrainingPlanRoutines
        if (!coachAppContext.TrainingPlanRoutines.Any())
        {
            var routineExerciseData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/TrainingPlanRoutineData.json");
            var routineExercises = JsonSerializer.Deserialize<List<TrainingPlanRoutines>>(routineExerciseData);
            if (routineExercises != null)
            {
                coachAppContext.TrainingPlanRoutines.AddRange(routineExercises);
                await coachAppContext.SaveChangesAsync();
            }
        }
        
        // Seed Roles
        if (!coachAppContext.Roles.Any())
        {
            var roleData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/RoleData.json");
            var roles = JsonSerializer.Deserialize<List<Role>>(roleData);
            if (roles != null)
            {
                coachAppContext.Roles.AddRange(roles);
                await coachAppContext.SaveChangesAsync();
            }
        }
        
        
        // Seed Avatars
        if (!coachAppContext.Avatars.Any())
        {
            var avatarData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/AvatarData.json");
            var avatars = JsonSerializer.Deserialize<List<Avatar>>(avatarData);
            if (avatars != null)
            {
                coachAppContext.Avatars.AddRange(avatars);
                await coachAppContext.SaveChangesAsync();
            }
        }
        
        // Seed Users
        if (!coachAppContext.Users.Any())
        {
            var usersData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/UserData.json");
            var users = JsonSerializer.Deserialize<List<User>>(usersData);
            if (users != null)
            {
                coachAppContext.Users.AddRange(users);
                await coachAppContext.SaveChangesAsync();
            }
        }
        // Seed Achievements
        if (!coachAppContext.Achievements.Any())
        {
            var achievementData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/AchievementData.json");
            var achievements = JsonSerializer.Deserialize<List<Achievement>>(achievementData);
            if (achievements != null)
            {
                coachAppContext.Achievements.AddRange(achievements);
                await coachAppContext.SaveChangesAsync();
            }
        }
        
        //Seed User Achievements
        if (!coachAppContext.UserAchievements.Any())
        {
            foreach (User user in coachAppContext.Users)
            {
                foreach (Achievement achievement in coachAppContext.Achievements)
                {
                    coachAppContext.UserAchievements.Add(new UserAchievements()
                    {
                        UserId = user.Id,
                        AchievementId = achievement.Id,
                        AchievementActualLevel = 0,
                        AchievementStepsProgress = 0
                    });
                    await coachAppContext.SaveChangesAsync();
                }  
            }
            
        }
        
    }
}