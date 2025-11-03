using HabitHero.Domain.Users.Entities;
using HabitHero.Domain.Users.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HabitHero.Infrastructure.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(x => x.Id);

            builder.HasMany(role => role.Permissions)
                .WithMany(permission => permission.Roles)
                .UsingEntity<RolePermission>(
                    left => left.HasOne<Permission>().WithMany().HasForeignKey(right => right.PermissionId),
                    right => right.HasOne<Role>().WithMany().HasForeignKey(left => left.RoleId));

            var roles = Enum
                .GetValues<RolesEnum>()
                .Select(role => new Role(
                    (int)role,
                    role.ToString()));

            builder.HasData(roles);
        }
    }
}
