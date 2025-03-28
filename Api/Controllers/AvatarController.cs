using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.GamificationEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AvatarController(
    IGenericRepository<Avatar> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AvatarResponseDTO>>> GetAll()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<AvatarResponseDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AvatarResponseDTO>> GetById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<AvatarResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> Create(CreateAvatarDTO dto)
    {
        var entity = mapper.Map<Avatar>(dto);
        repository.AddAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> Update(int id, CreateAvatarDTO dto)
    {
        var entity = mapper.Map<Avatar>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}