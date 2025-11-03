namespace HabitHero.Application.Common.Services.Authorization
{
    public interface IUserPermissionService
    {
        Task<string[]> GetUserPermissionsAsync(Guid userId);
    }
}
