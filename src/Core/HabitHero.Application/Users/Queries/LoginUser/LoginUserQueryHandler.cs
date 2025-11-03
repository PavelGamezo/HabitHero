using ErrorOr;
using HabitHero.Application.Common.CQRS.Queries;
using HabitHero.Application.Common.Persistence;
using HabitHero.Application.Common.Services;
using HabitHero.Application.Common.Services.Authentication;

namespace HabitHero.Application.Users.Queries.LoginUser
{
    public sealed class LoginUserQueryHandler : IQueryHandler<LoginUserQuery, ErrorOr<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public LoginUserQueryHandler(IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<ErrorOr<string>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var (email, password) = request;

            var user = await _userRepository.GetUserByEmailAsync(email, cancellationToken);
            if (user is null)
            {
                return Common.Errors.UserApplicationErrors.NotFoundUserError;
            }

            if (_passwordHasher.Verify(user.PasswordHash, password))
            {
                return Common.Errors.UserApplicationErrors.InvalidUserPasswordError;
            }

            var token = await _jwtTokenGenerator.GenerateToken(user.Id, user.Username, user.Email);

            return token;
        }
    }
}
