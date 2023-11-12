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
        modelBuilder.Entity<Project>()
            .ToTable("tb_project")
            .HasKey(x => x.Id);

        modelBuilder.Entity<Project>()
            .HasOne(x => x.Freelancer)
            .WithMany(x => x.FreelanceProjects)
            .HasForeignKey(x => x.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Project>()
            .HasOne(x => x.Client)
            .WithMany(x => x.OwnerProjects)
            .HasForeignKey(x => x.IdClient)
            .OnDelete(DeleteBehavior.Restrict);
        
        
        modelBuilder.Entity<ProjectComment>()
            .ToTable("tb_projectComment")
            .HasKey(x => x.Id);

        modelBuilder.Entity<ProjectComment>()
            .HasOne(x => x.Project)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.IdProject)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectComment>()
            .HasOne(x => x.User)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<User>()
            .ToTable("tb_user")
            .HasKey(x => x.Id);

        modelBuilder.Entity<User>()
            .HasMany(x => x.Skills)
            .WithOne()
            .HasForeignKey(x => x.IdSkill)
            .OnDelete(DeleteBehavior.Restrict);
    }
}