using HabitHero.Domain.Users.Entities;
using HabitHero.Domain.Users.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HabitHero.Infrastructure.Persistence.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");

            builder.HasKey(permission => permission.Id);

            var permissions = Enum
                .GetValues<PermissionsEnum>()
                .Select(permission => new Permission(
                    (int)permission, permission.ToString()));

            builder.HasData(permissions);
        }
    }
}
