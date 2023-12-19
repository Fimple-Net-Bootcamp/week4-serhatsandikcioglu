using Microsoft.EntityFrameworkCore;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<HealthCondition> HealthConditions { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<SocialInteraction> SocialInteractions { get; set; }
}
