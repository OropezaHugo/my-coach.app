using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class PrizeController(
    IGenericRepository<Prize> repository,
    IPrizeRepository prizeRepository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PrizeResponseDTO>>> GetPrizes()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<PrizeResponseDTO>(item)));
    }
    
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<UserPrizeInfoDTO>>> GetPrizesByUserId(int userId)
    {
        var items = await prizeRepository.GetPrizesByUserId(userId);
        return Ok(items.Select(item => mapper.Map<UserPrizeInfoDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PrizeResponseDTO>> GetPrizeById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<PrizeResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostPrize(CreatePrizeDTO dto)
    {
        var entity = mapper.Map<Prize>(dto);
        repository.AddAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutPrizeById(int id, CreatePrizeDTO dto)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        mapper.Map(dto, entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeletePrizeById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}