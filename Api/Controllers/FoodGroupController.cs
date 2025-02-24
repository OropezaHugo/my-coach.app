using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities.DietEntities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class FoodGroupController (
    IGenericRepository<FoodGroup> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodGroupResponseDTO>>> GetFoodGroups()
    {
        var foodGroups = await repository.ListAllAsync();
        return Ok(foodGroups.Select(foodGroup => mapper.Map<FoodGroupResponseDTO>(foodGroup)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FoodGroupResponseDTO>> GetFoodGroupById(int id)
    {
        var foodGroup = await repository.GetByIdAsync(id);
        if (foodGroup == null) return NotFound();
        return Ok(mapper.Map<FoodGroupResponseDTO>(foodGroup));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostFoodGroup(CreateFoodGroupDTO foodGroupDto)
    {
        var foodGroup = mapper.Map<FoodGroup>(foodGroupDto);
        repository.AddAsync(foodGroup);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutFoodGroupById(int id, CreateFoodGroupDTO foodGroupDto)
    {
        var foodGroup = mapper.Map<FoodGroup>((foodGroupDto, id));
        repository.AddAsync(foodGroup);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteFoodGroupById(int id)
    {
        var foodGroup = await repository.GetByIdAsync(id);
        if (foodGroup == null) return NotFound();
        repository.DeleteAsync(foodGroup);
        return Ok(await repository.SaveChangesAsync());
    }
}