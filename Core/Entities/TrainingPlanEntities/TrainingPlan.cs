namespace Core.Entities.TrainingPlanEntities;

public class TrainingPlan: BaseEntity
{
    public string Objective { get; set; } = string.Empty;
    public List<UserTrainingPlans> UserTrainingPlans { get; set; } = new List<UserTrainingPlans>();
    public List<TrainingPlanRoutines> TrainingPlanRoutines { get; set; } = new List<TrainingPlanRoutines>();
}