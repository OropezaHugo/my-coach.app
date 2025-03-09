using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ISAKMeasuresController(
    IGenericRepository<ISAKMeasures> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ISAKMeasuresResponseDTO>>> GetISAKMeasures()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<ISAKMeasuresResponseDTO>(item)));
    }
    
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<ISAKMeasuresResponseDTO>>> GetISAKMeasuresByUserId(int userId)
    {
        var spec = new BaseSpecification<ISAKMeasures>(measures => measures.UserId == userId);
        var items = await repository.ListAllAsync(spec);
        return Ok(items.Select(item => mapper.Map<ISAKMeasuresResponseDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ISAKMeasuresResponseDTO>> GetISAKMeasureById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<ISAKMeasuresResponseDTO>(item));
    }
    
    [HttpGet("user/{userId}/last")]
    public async Task<ActionResult<ISAKMeasuresResponseDTO>> GetLastISAKMeasureByUserId(int userId)
    {
        var spec = new LastMeasureSpecification(userId);
         
        var item = await repository.GetEntityWithSpec(spec);
        if (item == null) return NotFound();
        return Ok(mapper.Map<ISAKMeasuresResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostISAKMeasure(CreateISAKMeasuresDTO dto)
    {
        var entity = mapper.Map<ISAKMeasures>(dto);
        repository.AddAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutISAKMeasureById(int id, CreateISAKMeasuresDTO dto)
    {
        var entity = mapper.Map<ISAKMeasures>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteISAKMeasureById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}