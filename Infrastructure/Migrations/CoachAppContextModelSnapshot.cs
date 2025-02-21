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

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("Core.Entities.ExerciseEntities.Exercise", b =>
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

            modelBuilder.Entity("Core.Entities.ExerciseEntities.ExerciseSet", b =>
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

            modelBuilder.Entity("Core.Entities.ExerciseEntities.Routine", b =>
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

            modelBuilder.Entity("Core.Entities.ExerciseEntities.RoutineExercise", b =>
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

                    b.ToTable("RoutineExercise");
                });

            modelBuilder.Entity("Core.Entities.ExerciseEntities.Set", b =>
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

            modelBuilder.Entity("Core.Entities.Prize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("PrizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prizes");
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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
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

                    b.Property<int>("PrizeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrizeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPrizes");
                });

            modelBuilder.Entity("Core.Entities.UserRoutine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoutineId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("TargetDate")
                        .HasColumnType("date");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoutineId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoutines");
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

            modelBuilder.Entity("Core.Entities.ExerciseEntities.ExerciseSet", b =>
                {
                    b.HasOne("Core.Entities.ExerciseEntities.Exercise", "Exercise")
                        .WithMany("ExerciseSets")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ExerciseEntities.Set", "Set")
                        .WithMany("ExerciseSets")
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Set");
                });

            modelBuilder.Entity("Core.Entities.ExerciseEntities.RoutineExercise", b =>
                {
                    b.HasOne("Core.Entities.ExerciseEntities.Exercise", "Exercise")
                        .WithMany("RoutineExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ExerciseEntities.Routine", "Routine")
                        .WithMany("RoutineExercises")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Routine");
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
                    b.HasOne("Core.Entities.Prize", "Prize")
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

            modelBuilder.Entity("Core.Entities.UserRoutine", b =>
                {
                    b.HasOne("Core.Entities.ExerciseEntities.Routine", "Routine")
                        .WithMany("UserRoutines")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("UserRoutines")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Routine");

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

            modelBuilder.Entity("Core.Entities.ExerciseEntities.Exercise", b =>
                {
                    b.Navigation("ExerciseSets");

                    b.Navigation("RoutineExercises");
                });

            modelBuilder.Entity("Core.Entities.ExerciseEntities.Routine", b =>
                {
                    b.Navigation("RoutineExercises");

                    b.Navigation("UserRoutines");
                });

            modelBuilder.Entity("Core.Entities.ExerciseEntities.Set", b =>
                {
                    b.Navigation("ExerciseSets");
                });

            modelBuilder.Entity("Core.Entities.Prize", b =>
                {
                    b.Navigation("UserPrizes");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("UserDiets");

                    b.Navigation("UserPrizes");

                    b.Navigation("UserRoutines");
                });
#pragma warning restore 612, 618
        }
    }
}
