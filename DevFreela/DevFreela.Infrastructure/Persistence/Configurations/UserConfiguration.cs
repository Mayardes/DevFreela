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

        builder.HasOne(x => x.Skills)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }
}