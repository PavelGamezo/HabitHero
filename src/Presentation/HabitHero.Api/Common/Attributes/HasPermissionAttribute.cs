using HabitHero.Application.Common.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace HabitHero.Api.Common.Attributes
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(Permissions permission)
            : base(policy: permission.ToString()) 
        {
        }
    }
}
