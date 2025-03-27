using System.Security.Cryptography.X509Certificates;
using System.Text;
using Api.Handlers;
using Api.Handlers.Requirements;
using Api.Jobs;
using Api.Profiles;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<CoachAppContext>(
    optionsBuilder =>
    {
        optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureHttpsDefaults(adapterOptions =>
    {
        adapterOptions.ServerCertificate = new X509Certificate2(
            "../ssl/localhost.pfx", ""
        );
    });
});
var secretKey = builder.Configuration["Jwt:SecretKey"];
if (secretKey != null)
{
    var key = Encoding.UTF8.GetBytes(secretKey);

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });
}

builder.Services.AddSingleton<IAuthorizationHandler, CoachOrSelfAuthorizationHandler>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SelfOrCoachAccess", policyBuilder => 
        policyBuilder.Requirements.Add(new EmptyRequirement()));
});
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDietRepository, DietRepository>();
builder.Services.AddScoped<ITrainingPlanRepository, TrainingPlanRepository>();
builder.Services.AddScoped<ITrainingRecordRepository, TrainingRecordRepository>();
builder.Services.AddScoped<ISetRepository, SetRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IPrizeRepository, PrizeRepository>();
builder.Services.AddScoped<IAchievementRepository, AchievementRepository>();
builder.Services.AddScoped<IUserAchievementRepository, UserAchievementRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddQuartz(q =>
{
    var jobKey = new JobKey("PushNotificationJob");
    q.AddJob<PushNotificationJob>(opts => opts.WithIdentity(jobKey));
    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("DailyTrigger")
        .WithCronSchedule("0 * * * * ?", scheduleBuilder => scheduleBuilder.InTimeZone(TimeZoneInfo.Local).Build()));
});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
var app = builder.Build();
app.UseRouting();

app.UseCors(policyBuilder =>
{
    policyBuilder.AllowCredentials()
        .WithOrigins("https://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
});

app.UseAuthentication();
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
