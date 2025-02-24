using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities.DietEntities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class DietFoodGroupController(
    IGenericRepository<DietFoodGroup> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DietFoodGroupResponseDTO>>> GetDietFoodGroups()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<DietFoodGroupResponseDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DietFoodGroupResponseDTO>> GetDietFoodGroupById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<DietFoodGroupResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostDietFoodGroup(CreateDietFoodGroupDTO dto)
    {
        var entity = mapper.Map<DietFoodGroup>(dto);
        repository.AddAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutDietFoodGroupById(int id, CreateDietFoodGroupDTO dto)
    {
        var entity = mapper.Map<DietFoodGroup>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteDietFoodGroupById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}
