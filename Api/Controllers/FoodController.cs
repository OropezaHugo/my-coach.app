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
public class FoodController (
    IGenericRepository<Food> repository,
    IFoodRepository foodRepository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodResponseDTO>>> GetFoods()
    {
        var foods = await repository.ListAllAsync();
        return Ok(foods.Select(food => mapper.Map<FoodResponseDTO>(food)));
    }
    
    [HttpGet("filtercontent")]
    public async Task<ActionResult<IEnumerable<FoodFoodGroupsAndFoodSubGroupsFilterDTO>>> GetFoodsFilterContent()
    {
        
        var filterContent = await foodRepository.GetFoodGroupsAndFoodSubGroups();
        return Ok(filterContent);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FoodResponseDTO>> GetFoodById(int id)
    {
        var food = await repository.GetByIdAsync(id);
        if (food == null) return NotFound();
        return Ok(mapper.Map<FoodResponseDTO>(food));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostFood(CreateFoodDTO foodDto)
    {
        var food = mapper.Map<Food>(foodDto);
        repository.AddAsync(food);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutFoodById(int id, CreateFoodDTO foodDto)
    {
        var food = mapper.Map<Food>((foodDto, id));
        repository.AddAsync(food);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteFoodById(int id)
    {
        var food = await repository.GetByIdAsync(id);
        if (food == null) return NotFound();
        repository.DeleteAsync(food);
        return Ok(await repository.SaveChangesAsync());
    }
}
