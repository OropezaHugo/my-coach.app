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
var app = builder.Build();

app.MapControllers();
app.Run();
