using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserTrainingPlanController
(
    IGenericRepository<UserTrainingPlans> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserTrainingPlanResponseDTO>>> GetUserTrainingPlans()
    {
        var userTrainingPlans = await repository.ListAllAsync();
        return Ok(userTrainingPlans.Select(userTrainingPlan => mapper.Map<UserTrainingPlanResponseDTO>(userTrainingPlan)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserTrainingPlanResponseDTO>> GetUserTrainingPlanById(int id)
    {
        var userTrainingPlan = await repository.GetByIdAsync(id);
        if (userTrainingPlan == null) return NotFound();
        return Ok(mapper.Map<UserTrainingPlanResponseDTO>(userTrainingPlan));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostUserTrainingPlan(CreateUserTrainingPlanDTO userTrainingPlanDto)
    {
        var userTrainingPlan = mapper.Map<UserTrainingPlans>(userTrainingPlanDto);
        repository.AddAsync(userTrainingPlan);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutUserTrainingPlanById(int id, CreateUserTrainingPlanDTO userTrainingPlanDto)
    {
        var userTrainingPlan = mapper.Map<UserTrainingPlans>((userTrainingPlanDto, id));
        repository.UpdateAsync(userTrainingPlan);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUserTrainingPlanById(int id)
    {
        var userTrainingPlan = await repository.GetByIdAsync(id);
        if (userTrainingPlan == null) return NotFound();
        repository.DeleteAsync(userTrainingPlan);
        return Ok(await repository.SaveChangesAsync());
    }
}