using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController(
    IGenericRepository<Role> repository,
    IMapper mapper
): ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleResponseDTO>>> GetRoles()
    {
        var roles = await repository.ListAllAsync();
        return Ok(roles.Select(role => mapper.Map<RoleResponseDTO>(role)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleResponseDTO>> GetRoleById(int id)
    {
        var role = await repository.GetByIdAsync(id);
        if (role == null) return NotFound();
        return Ok(mapper.Map<UserResponseDTO>(role));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostRole(CreateRoleDTO roleDto)
    {
        var role = mapper.Map<Role>(roleDto);
        repository.AddAsync(role);
        return Ok(await repository.SaveChangesAsync());
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutRoleById(int id, CreateRoleDTO roleDto)
    {
        var role = mapper.Map<Role>((roleDto, id));
        repository.AddAsync(role);
        return Ok(await repository.SaveChangesAsync());
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteRoleById(int id)
    {
        var role = await repository.GetByIdAsync(id);
        if (role == null) return NotFound();
        repository.DeleteAsync(role);
        return Ok(await repository.SaveChangesAsync());
    }
}