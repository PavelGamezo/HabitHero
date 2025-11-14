using HabitHero.Domain.Users;

namespace HabitHero.Application.Common.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);

        Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<User?> GetUserWithHabitsByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<User?> GetUserWithHabitsByIdWithNoTrackingAsync(Guid id, CancellationToken cancellationToken);

        Task<User?> GetUserByIdWithNoTrackingAsync(Guid id, CancellationToken cancellationToken);

        Task<bool> IsUserExistAsync(string email, string username, CancellationToken cancellationToken);

        void AddUser(User user);

        void DeleteUser(User user);

        void UpdateUser(User user);

        Task SaveAsync(CancellationToken cancellationToken);
    }
}
