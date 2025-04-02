using Core.Entities.TrainingPlanEntities;
using FluentAssertions;
using Infrastructure.Data;
using Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Tests.Infrastructure;

public class SetRepositoryTests
{
    [Fact]
    public async Task GetSetsByExerciseId_ShouldReturnFilteredSets()
    {
        var options = new DbContextOptionsBuilder<CoachAppContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        using (var context = new CoachAppContext(options))
        {
            var exercise = new Exercise { Id = 1, ExerciseName = "Push ups"};
            var exercise2 = new Exercise { Id = 2, ExerciseName = "Pull ups"};
            var set = new Set { Id = 1 };
            var set2 = new Set { Id = 2 };
            var set3 = new Set { Id = 3 };
            context.Sets.Add(set);
            context.Sets.Add(set2);
            context.Sets.Add(set3);
            context.ExerciseSets.Add(new ExerciseSet { ExerciseId = 1, SetId = 1 });
            context.ExerciseSets.Add(new ExerciseSet { ExerciseId = 2, SetId = 2 });
            context.ExerciseSets.Add(new ExerciseSet { ExerciseId = 1, SetId = 3 });
            await context.SaveChangesAsync();
        }

        using (var context = new CoachAppContext(options))
        {
            var repo = new SetRepository(context);

            var result = await repo.GetSetsByExerciseId(1);

            result.Should().HaveCount(2);
            result.First().Id.Should().Be(1);
        }
    }
}