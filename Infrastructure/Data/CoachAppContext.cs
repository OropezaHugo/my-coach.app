using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class CoachAppContext(DbContextOptions options) : DbContext(options)
{
    
}