using System.Security.Claims;
using Api.Handlers.Requirements;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Api.Handlers;

public class CoachOrSelfAuthorizationHandler(
    IHttpContextAccessor httpContextAccessor
        ): AuthorizationHandler<EmptyRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmptyRequirement requirement)
    {
        var userClaims = httpContextAccessor.HttpContext?.User;
        
        var role = userClaims?.FindFirst(ClaimTypes.Role)?.Value;
        var email = userClaims?.FindFirst(ClaimTypes.Email)?.Value;
        if (role == "Coach")
        {
            
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        if (role == "Student" && email != null)
        {
            var routeValues = httpContextAccessor.HttpContext?.Request.RouteValues;
            if (routeValues != null && routeValues.TryGetValue("email", out var emailObj) && emailObj is string emailRes)
            {
                if (emailRes == email) 
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
        }

        context.Fail();
        return Task.CompletedTask;
    }
}