using Api.Profiles;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<CoachAppContext>(
    optionsBuilder =>
    {
        optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDietRepository, DietRepository>();
builder.Services.AddScoped<IFoodGroupRepository, FoodGroupRepository>();
builder.Services.AddAutoMapper(typeof(UserProfile));

var app = builder.Build();

app.UseCors(policyBuilder =>
{
    policyBuilder.AllowCredentials()
        .WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

try
{
    using var scoped = app.Services.CreateScope();
    var services = scoped.ServiceProvider;
    var context = services.GetRequiredService<CoachAppContext>();
    await context.Database.MigrateAsync();
    await CoachAppSeed.SeedAsync(context);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
app.Run();
