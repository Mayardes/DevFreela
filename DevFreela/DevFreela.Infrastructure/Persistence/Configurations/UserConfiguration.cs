using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("tb_user")
            .HasKey(x => x.Id);

        builder.HasMany(x => x.Skills)
            .WithOne()
            .HasForeignKey(x => x.IdSkill)
            .OnDelete(DeleteBehavior.Restrict);
    }
}