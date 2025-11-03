using Microsoft.AspNetCore.Authorization;

namespace HabitHero.Api.Common.Attributes
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(Domain.Users.Enums.PermissionsEnum permission)
            : base(policy: permission.ToString()) 
        {
        }
    }
}
