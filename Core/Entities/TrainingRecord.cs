using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.TrainingPlanEntities;

namespace Core.Entities;

public class TrainingRecord: BaseEntity
{
    public double WeightLifted { get; set; }
    public int RepetitionsMade { get; set; }
    public DateOnly RecordDate { get; set; }
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    
    public int ExerciseId { get; set; }
    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }
}