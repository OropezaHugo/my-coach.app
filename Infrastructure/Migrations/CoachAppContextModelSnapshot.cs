﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CoachAppContext))]
    partial class CoachAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.DietEntities.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DietName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("WaterAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("Core.Entities.DietEntities.DietFoodGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.Property<int>("FoodGroupId")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("FoodGroupTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("DietId");

                    b.HasIndex("FoodGroupId");

                    b.ToTable("DietFoodGroups");
                });

            modelBuilder.Entity("Core.Entities.DietEntities.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("FoodAshGr")
                        .HasColumnType("float");

                    b.Property<double>("FoodCalciumGr")
                        .HasColumnType("float");

                    b.Property<double>("FoodCarbsGr")
                        .HasColumnType("float");

                    b.Property<double>("FoodEnergyKcal")
                        .HasColumnType("float");

                    b.Property<double>("FoodFatGr")
                        .HasColumnType("float");

                    b.Property<double>("FoodFibberGr")
                        .HasColumnType("float");

                    b.Property<string>("FoodGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FoodHumidityGr")
                        .HasColumnType("float");

                    b.Property<double>("FoodIronMg")
                        .HasColumnType("float");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FoodPhosphorusMg")
                        .HasColumnType("float");

                    b.Property<double>("FoodProteinGr")
                        .HasColumnType("float");

                    b.Property<string>("FoodSubGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FoodVitaminAMig")
                        .HasColumnType("float");

                    b.Property<double>("FoodVitaminB1Mg")
                        .HasColumnType("float");

                    b.Property<double>("FoodVitaminB2Mg")
                        .HasColumnType("float");

                    b.Property<double>("FoodVitaminB3Mg")
                        .HasColumnType("float");

                    b.Property<double>("FoodVitaminCMg")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Core.Entities.DietEntities.FoodGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FoodGroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FoodGroups");
                });

            modelBuilder.Entity("Core.Entities.DietEntities.FoodGroupFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("FoodAmount")
                        .HasColumnType("float");

                    b.Property<int>("FoodGroupId")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodGroupId");

                    b.HasIndex("FoodId");

                    b.ToTable("FoodGroupFoods");
                });

            modelBuilder.Entity("Core.Entities.GamificationEntities.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AchievementImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AchievementName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.PrimitiveCollection<string>("AchievementStepsPerLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AchievementType")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("ObtainingDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("Core.Entities.GamificationEntities.NotificationSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Auth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endpoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("P256dh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("NotificationSubscriptions");
                });

            modelBuilder.Entity("Core.Entities.GamificationEntities.Prize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("PrizeImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prizes");
                });

            modelBuilder.Entity("Core.Entities.ISAKMeasures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("AbdominalMm")
                        .HasColumnType("real");

                    b.Property<float>("BicepsMm")
                        .HasColumnType("real");

                    b.Property<float>("CalfCm")
                        .HasColumnType("real");

                    b.Property<float>("ElbowDiameterCm")
                        .HasColumnType("real");

                    b.Property<float>("FlexedArmCm")
                        .HasColumnType("real");

                    b.Property<float>("FootLengthCm")
                        .HasColumnType("real");

                    b.Property<float>("FrontThighMm")
                        .HasColumnType("real");

                    b.Property<float>("HipCm")
                        .HasColumnType("real");

                    b.Property<float>("IliacCrestMm")
                        .HasColumnType("real");

                    b.Property<float>("KneeDiameterCm")
                        .HasColumnType("real");

                    b.Property<DateOnly>("MeasureDate")
                        .HasColumnType("date");

                    b.Property<float>("MedialCalfMm")
                        .HasColumnType("real");

                    b.Property<float>("MidThighCm")
                        .HasColumnType("real");

                    b.Property<float>("RelaxedArmCm")
                        .HasColumnType("real");

                    b.Property<float>("SubscapularMm")
                        .HasColumnType("real");

                    b.Property<float>("SupraespinalMm")
                        .HasColumnType("real");

                    b.Property<float>("TotalHeightMts")
                        .HasColumnType("real");

                    b.Property<float>("TricepsMm")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<float>("WaistCm")
                        .HasColumnType("real");

                    b.Property<float>("WeightKg")
                        .HasColumnType("real");

                    b.Property<float>("WingspanCm")
                        .HasColumnType("real");

                    b.Property<float>("WristDiameterCm")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IsakMeasures");
                });

            modelBuilder.Entity("Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.ExerciseSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("Fatigue")
                        .HasColumnType("int");

                    b.Property<int>("SetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("SetId");

                    b.ToTable("ExerciseSets");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.Routine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoutineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Routines");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.RoutineExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Effort")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("RoutineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("RoutineId");

                    b.ToTable("RoutineExercises");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.Set", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Repetitions")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.TrainingPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Objective")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrainingPlans");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.TrainingPlanRoutines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeOnly>("ArrivalTime")
                        .HasColumnType("time");

                    b.Property<int>("RoutineId")
                        .HasColumnType("int");

                    b.Property<string>("RoutineWeekDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoutineId");

                    b.HasIndex("TrainingPlanId");

                    b.ToTable("TrainingPlanRoutines");
                });

            modelBuilder.Entity("Core.Entities.TrainingRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("RecordDate")
                        .HasColumnType("date");

                    b.Property<int>("RepetitionsMade")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("WeightLifted")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("UserId");

                    b.ToTable("TrainingRecords");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.UserAchievements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AchievementActualLevel")
                        .HasColumnType("int");

                    b.Property<int>("AchievementId")
                        .HasColumnType("int");

                    b.Property<int>("AchievementStepsProgress")
                        .HasColumnType("int");

                    b.Property<bool>("IsBadge")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AchievementId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAchievements");
                });

            modelBuilder.Entity("Core.Entities.UserDiet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("AssignedDate")
                        .HasColumnType("date");

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DietId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDiets");
                });

            modelBuilder.Entity("Core.Entities.UserPrize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("ObtainedDate")
                        .HasColumnType("date");

                    b.Property<int>("PrizeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrizeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPrizes");
                });

            modelBuilder.Entity("Core.Entities.UserTrainingPlans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("AssignedDate")
                        .HasColumnType("date");

                    b.Property<int>("TrainingPlanId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainingPlanId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTrainingPlans");
                });

            modelBuilder.Entity("Core.Entities.DietEntities.DietFoodGroup", b =>
                {
                    b.HasOne("Core.Entities.DietEntities.Diet", "Diet")
                        .WithMany("DietFoodGroups")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.DietEntities.FoodGroup", "FoodGroup")
                        .WithMany("DietFoodGroups")
                        .HasForeignKey("FoodGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("FoodGroup");
                });

            modelBuilder.Entity("Core.Entities.DietEntities.FoodGroupFood", b =>
                {
                    b.HasOne("Core.Entities.DietEntities.FoodGroup", "FoodGroup")
                        .WithMany("FoodGroupFoods")
                        .HasForeignKey("FoodGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.DietEntities.Food", "Food")
                        .WithMany("FoodGroupFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("FoodGroup");
                });

            modelBuilder.Entity("Core.Entities.GamificationEntities.Achievement", b =>
                {
                    b.HasOne("Core.Entities.TrainingPlanEntities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("Core.Entities.GamificationEntities.NotificationSubscription", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.ISAKMeasures", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.ExerciseSet", b =>
                {
                    b.HasOne("Core.Entities.TrainingPlanEntities.Exercise", "Exercise")
                        .WithMany("ExerciseSets")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TrainingPlanEntities.Set", "Set")
                        .WithMany("ExerciseSets")
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Set");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.RoutineExercise", b =>
                {
                    b.HasOne("Core.Entities.TrainingPlanEntities.Exercise", "Exercise")
                        .WithMany("RoutineExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TrainingPlanEntities.Routine", "Routine")
                        .WithMany("RoutineExercises")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Routine");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.TrainingPlanRoutines", b =>
                {
                    b.HasOne("Core.Entities.TrainingPlanEntities.Routine", "Routine")
                        .WithMany("TrainingPlanRoutines")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TrainingPlanEntities.TrainingPlan", "TrainingPlan")
                        .WithMany("TrainingPlanRoutines")
                        .HasForeignKey("TrainingPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Routine");

                    b.Navigation("TrainingPlan");
                });

            modelBuilder.Entity("Core.Entities.TrainingRecord", b =>
                {
                    b.HasOne("Core.Entities.TrainingPlanEntities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.HasOne("Core.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Core.Entities.UserAchievements", b =>
                {
                    b.HasOne("Core.Entities.GamificationEntities.Achievement", "Achievement")
                        .WithMany("UserAchievements")
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("UserAchievements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Achievement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.UserDiet", b =>
                {
                    b.HasOne("Core.Entities.DietEntities.Diet", "Diet")
                        .WithMany("UserDiets")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("UserDiets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.UserPrize", b =>
                {
                    b.HasOne("Core.Entities.GamificationEntities.Prize", "Prize")
                        .WithMany("UserPrizes")
                        .HasForeignKey("PrizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("UserPrizes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prize");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.UserTrainingPlans", b =>
                {
                    b.HasOne("Core.Entities.TrainingPlanEntities.TrainingPlan", "TrainingPlan")
                        .WithMany("UserTrainingPlans")
                        .HasForeignKey("TrainingPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("UserTrainingPlans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingPlan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.DietEntities.Diet", b =>
                {
                    b.Navigation("DietFoodGroups");

                    b.Navigation("UserDiets");
                });

            modelBuilder.Entity("Core.Entities.DietEntities.Food", b =>
                {
                    b.Navigation("FoodGroupFoods");
                });

            modelBuilder.Entity("Core.Entities.DietEntities.FoodGroup", b =>
                {
                    b.Navigation("DietFoodGroups");

                    b.Navigation("FoodGroupFoods");
                });

            modelBuilder.Entity("Core.Entities.GamificationEntities.Achievement", b =>
                {
                    b.Navigation("UserAchievements");
                });

            modelBuilder.Entity("Core.Entities.GamificationEntities.Prize", b =>
                {
                    b.Navigation("UserPrizes");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.Exercise", b =>
                {
                    b.Navigation("ExerciseSets");

                    b.Navigation("RoutineExercises");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.Routine", b =>
                {
                    b.Navigation("RoutineExercises");

                    b.Navigation("TrainingPlanRoutines");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.Set", b =>
                {
                    b.Navigation("ExerciseSets");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanEntities.TrainingPlan", b =>
                {
                    b.Navigation("TrainingPlanRoutines");

                    b.Navigation("UserTrainingPlans");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("UserAchievements");

                    b.Navigation("UserDiets");

                    b.Navigation("UserPrizes");

                    b.Navigation("UserTrainingPlans");
                });
#pragma warning restore 612, 618
        }
    }
}
