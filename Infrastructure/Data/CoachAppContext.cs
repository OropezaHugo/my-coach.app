using Core.Entities;
using Core.Entities.DietEntities;
using Core.Entities.GamificationEntities;
using Core.Entities.TrainingPlanEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class CoachAppContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ISAKMeasures> IsakMeasures { get; set; }
    public DbSet<TrainingRecord> TrainingRecords { get; set; }
    
    public DbSet<Prize> Prizes { get; set; }
    public DbSet<UserPrize> UserPrizes { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
    public DbSet<UserAchievements> UserAchievements { get; set; }
    
    public DbSet<Food> Foods { get; set; }
    public DbSet<FoodGroupFood> FoodGroupFoods { get; set; }
    public DbSet<FoodGroup> FoodGroups { get; set; }
    public DbSet<DietFoodGroup> DietFoodGroups { get; set; }
    public DbSet<Diet> Diets { get; set; }
    public DbSet<UserDiet> UserDiets { get; set; }
    
    public DbSet<Set> Sets { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseSet> ExerciseSets { get; set; }
    public DbSet<Routine> Routines { get; set; }
    public DbSet<RoutineExercise> RoutineExercises { get; set; }
    public DbSet<TrainingPlanRoutines> TrainingPlanRoutines { get; set; }
    public DbSet<TrainingPlan> TrainingPlans { get; set; }
    public DbSet<UserTrainingPlans> UserTrainingPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDiet>()
            .HasOne(ud => ud.User)
            .WithMany(u => u.UserDiets)
            .HasForeignKey(ud => ud.UserId);
        modelBuilder.Entity<UserDiet>()
            .HasOne(ud => ud.Diet)
            .WithMany(u => u.UserDiets)
            .HasForeignKey(ud => ud.DietId);
        
        modelBuilder.Entity<UserTrainingPlans>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserTrainingPlans)
            .HasForeignKey(ur => ur.UserId);
        modelBuilder.Entity<UserTrainingPlans>()
            .HasOne(ur => ur.TrainingPlan)
            .WithMany(u => u.UserTrainingPlans)
            .HasForeignKey(ur => ur.TrainingPlanId);
        
        modelBuilder.Entity<UserPrize>()
            .HasOne(pu => pu.User)
            .WithMany(u => u.UserPrizes)
            .HasForeignKey(pu => pu.UserId);
        modelBuilder.Entity<UserPrize>()
            .HasOne(pu => pu.Prize)
            .WithMany(u => u.UserPrizes)
            .HasForeignKey(pu => pu.PrizeId);
        
        modelBuilder.Entity<UserAchievements>()
            .HasOne(ua => ua.User)
            .WithMany(u => u.UserAchievements)
            .HasForeignKey(ua => ua.UserId);
        modelBuilder.Entity<UserAchievements>()
            .HasOne(ua => ua.Achievement)
            .WithMany(u => u.UserAchievements)
            .HasForeignKey(ua => ua.AchievementId);
        
        modelBuilder.Entity<DietFoodGroup>()
            .HasOne(dfg => dfg.Diet)
            .WithMany(d => d.DietFoodGroups)
            .HasForeignKey(dfg => dfg.DietId);
        modelBuilder.Entity<DietFoodGroup>()
            .HasOne(dfg => dfg.FoodGroup)
            .WithMany(d => d.DietFoodGroups)
            .HasForeignKey(dfg => dfg.FoodGroupId);
        
        modelBuilder.Entity<FoodGroupFood>()
            .HasOne(fk => fk.FoodGroup)
            .WithMany(f => f.FoodGroupFoods)
            .HasForeignKey(fk => fk.FoodGroupId);
        modelBuilder.Entity<FoodGroupFood>()
            .HasOne(fk => fk.Food)
            .WithMany(f => f.FoodGroupFoods)
            .HasForeignKey(fk => fk.FoodId);
        
        modelBuilder.Entity<TrainingPlanRoutines>()
            .HasOne(tp => tp.TrainingPlan)
            .WithMany(pt => pt.TrainingPlanRoutines)
            .HasForeignKey(tp => tp.TrainingPlanId);
        modelBuilder.Entity<TrainingPlanRoutines>()
            .HasOne(tp => tp.Routine)
            .WithMany(pt => pt.TrainingPlanRoutines)
            .HasForeignKey(tp => tp.RoutineId);
        
        modelBuilder.Entity<RoutineExercise>()
            .HasOne(rc => rc.Routine)
            .WithMany(r => r.RoutineExercises)
            .HasForeignKey(rc => rc.RoutineId);
        modelBuilder.Entity<RoutineExercise>()
            .HasOne(rc => rc.Exercise)
            .WithMany(r => r.RoutineExercises)
            .HasForeignKey(rc => rc.ExerciseId);
        
        modelBuilder.Entity<ExerciseSet>()
            .HasOne(rs => rs.Exercise)
            .WithMany(rs => rs.ExerciseSets)
            .HasForeignKey(rs => rs.ExerciseId);
        modelBuilder.Entity<ExerciseSet>()
            .HasOne(rs => rs.Set)
            .WithMany(rs => rs.ExerciseSets)
            .HasForeignKey(rs => rs.SetId);
    }
}