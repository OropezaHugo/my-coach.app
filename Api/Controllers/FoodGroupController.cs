using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.DietEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Core.Specifications;
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

    [HttpGet("names")]
    public async Task<ActionResult<IEnumerable<string>>> GetFoodGroupNames()
    {
        var spec = new FoodGroupNameListSpecification();
        var foodGroupNames = await repository.ListAllAsync(spec);
        return Ok(foodGroupNames);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FoodGroupResponseDTO>> GetFoodGroupById(int id)
    {
        var foodGroup = await repository.GetByIdAsync(id);
        if (foodGroup == null) return NotFound();
        return Ok(mapper.Map<FoodGroupResponseDTO>(foodGroup));
    }

    [HttpPost]
    public async Task<ActionResult<FoodGroupResponseDTO>> PostFoodGroup(CreateFoodGroupDTO foodGroupDto)
    {
        var foodGroup = mapper.Map<FoodGroup>(foodGroupDto);
        var newFoodGroup = repository.AddAsync(foodGroup);
        await repository.SaveChangesAsync();
        return Ok(mapper.Map<FoodGroupResponseDTO>(newFoodGroup));
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