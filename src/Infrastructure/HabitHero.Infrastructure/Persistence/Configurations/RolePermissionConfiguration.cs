using HabitHero.Domain.Users.Entities;
using HabitHero.Domain.Users.Enums;
using HabitHero.Infrastructure.Common.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace HabitHero.Infrastructure.Persistence.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        private readonly AuthorizationOptions _authorizationOptions;

        public RolePermissionConfiguration(AuthorizationOptions authorizationOptions)
        {
            _authorizationOptions = authorizationOptions;
        }

        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(rolePermission => new { rolePermission.PermissionId, rolePermission.RoleId });

            builder.HasData(ParseRolePermission());
        }

        private RolePermission[] ParseRolePermission()
        {
            return _authorizationOptions
                .RolePermissions
                .SelectMany(rolePermission => rolePermission.Permissions
                    .Select(permissions => new RolePermission
                    {
                        RoleId = (int)Enum.Parse<RolesEnum>(rolePermission.Role),
                        PermissionId = (int)Enum.Parse<PermissionsEnum>(permissions)
                    }))
                .ToArray();
        }
    }
}
