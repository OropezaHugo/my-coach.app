using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.TrainingPlanEntities;

namespace Core.Entities;

public class UserTrainingPlans: BaseEntity
{
    
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    
    public int TrainingPlanId { get; set; }
    [ForeignKey(nameof(TrainingPlanId))]
    public TrainingPlan? TrainingPlan { get; set; }
    
    public DateOnly AssignedDate { get; set; }
}