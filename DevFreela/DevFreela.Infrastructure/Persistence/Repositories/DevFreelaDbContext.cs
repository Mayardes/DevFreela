using System.Reflection;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;
public class DevFreelaDbContext : DbContext
{
    public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> context) : base(context)
    {
        Database.EnsureCreated();
    }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectComment> ProjectComments { get; set; }
    
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}