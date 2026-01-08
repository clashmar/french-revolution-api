using french_revolution_api.Models;
using Microsoft.EntityFrameworkCore;

namespace french_revolution_api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Character> Characters => Set<Character>();
}