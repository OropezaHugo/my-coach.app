using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.DietEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class FoodGroupFoodController(
    IGenericRepository<FoodGroupFood> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodGroupFoodResponseDTO>>> GetFoodGroupFoods()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<FoodGroupFoodResponseDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FoodGroupFoodResponseDTO>> GetFoodGroupFoodById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<FoodGroupFoodResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostFoodGroupFood(CreateFoodGroupFoodDTO dto)
    {
        var entity = mapper.Map<FoodGroupFood>(dto);
        repository.AddAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutFoodGroupFoodById(int id, CreateFoodGroupFoodDTO dto)
    {
        var entity = mapper.Map<FoodGroupFood>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteFoodGroupFoodById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}