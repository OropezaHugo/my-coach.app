using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserPrizeController(
    IGenericRepository<UserPrize> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserPrizeResponseDTO>>> GetUserPrizes()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<UserPrizeResponseDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserPrizeResponseDTO>> GetUserPrizeById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<UserPrizeResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostUserPrize(CreateUserPrizeDTO dto)
    {
        var entity = mapper.Map<UserPrize>(dto);
        repository.AddAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutUserPrizeById(int id, CreateUserPrizeDTO dto)
    {
        var entity = mapper.Map<UserPrize>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUserPrizeById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}
