using Api.RequestDTOs;
using Api.ResponseDTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController
    (
        IGenericRepository<User> repository,
        IMapper mapper
        ): ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetUsers()
    {
        var users = await repository.ListAllAsync();
        return Ok(users.Select(user => mapper.Map<UserResponseDTO>(user)));
    }
    
    [HttpGet("role/{roleId}")]
    public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetUsersByRoleId(int roleId)
    {
        var spec = new BaseSpecification<User>(user => user.RoleId == roleId);
        var users = await repository.ListAllAsync(spec);
        return Ok(users.Select(user => mapper.Map<UserResponseDTO>(user)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDTO>> GetUserById(int id)
    {
        var user = await repository.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(mapper.Map<UserResponseDTO>(user));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostUser(CreateUserDTO userDto)
    {
        var user = mapper.Map<User>(userDto);
        repository.AddAsync(user);
        return Ok(await repository.SaveChangesAsync());
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutUserById(int id, CreateUserDTO userDto)
    {
        var user = mapper.Map<User>((userDto, id));
        repository.AddAsync(user);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUserById(int id)
    {
        var user = await repository.GetByIdAsync(id);
        if (user == null) return NotFound();
        repository.DeleteAsync(user);
        return Ok(await repository.SaveChangesAsync());
    }
}