using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.TrainingPlanEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TrainingPlanController
(
    IGenericRepository<TrainingPlan> repository,
    ITrainingPlanRepository trainingPlanRepository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainingPlanResponseDTO>>> GetTrainingPlans()
    {
        var trainingPlans = await repository.ListAllAsync();
        return Ok(trainingPlans.Select(trainingPlan => mapper.Map<TrainingPlanResponseDTO>(trainingPlan)));
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<UserTrainingPlanInfoDTO>>> GetTrainingPlansByUserId(int userId)
    {
        var trainingPlans = await trainingPlanRepository.GetTrainingPlansByUserId(userId);
        return Ok(trainingPlans.Select(trainingPlan => mapper.Map<UserTrainingPlanInfoDTO>(trainingPlan)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TrainingPlanResponseDTO>> GetTrainingPlanById(int id)
    {
        var trainingPlan = await repository.GetByIdAsync(id);
        if (trainingPlan == null) return NotFound();
        return Ok(mapper.Map<TrainingPlanResponseDTO>(trainingPlan));
    }
    [HttpGet("{id}/content")]
    public async Task<ActionResult<TrainingPlanResponseDTO>> GetTrainingPlanContentByTrainingPlanId(int id)
    {
        var trainingPlanContent = await trainingPlanRepository.GetTrainingPlanContentByTrainingPlanId(id);
        if (trainingPlanContent == null) return NotFound();
        return Ok(trainingPlanContent);
    }

    [HttpPost]
    public async Task<ActionResult<TrainingPlanResponseDTO>> PostTrainingPlan(CreateTrainingPlanDTO trainingPlanDto)
    {
        var trainingPlan = mapper.Map<TrainingPlan>(trainingPlanDto);
        var newPlan = repository.AddAsync(trainingPlan);
        await repository.SaveChangesAsync();
        return Ok(mapper.Map<TrainingPlanResponseDTO>(newPlan));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutTrainingPlanById(int id, CreateTrainingPlanDTO trainingPlanDto)
    {
        var trainingPlan = mapper.Map<TrainingPlan>((trainingPlanDto, id));
        repository.UpdateAsync(trainingPlan);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteTrainingPlanById(int id)
    {
        var trainingPlan = await repository.GetByIdAsync(id);
        if (trainingPlan == null) return NotFound();
        repository.DeleteAsync(trainingPlan);
        return Ok(await repository.SaveChangesAsync());
    }
}