using ErrorOr;
using HabitHero.Application.Common.Authentication;
using HabitHero.Application.Common.CQRS.Commands;
using HabitHero.Application.Common.Errors;
using HabitHero.Application.Common.Persistence;
using HabitHero.Domain.Common.Factory;
using HabitHero.Domain.Users;

namespace HabitHero.Application.Users.Commands.RegisterUser
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, ErrorOr<Success>>
    {
        private readonly IUserRepository _userRepository; 
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserFactory _userFactory;

        public RegisterUserCommandHandler(IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IUserFactory userFactory)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userFactory = userFactory;
        }

        public async Task<ErrorOr<Success>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var (username, email, password) = request;
            if (await _userRepository.IsUserExistAsync(email, password, cancellationToken))
            {
                return UserApplicationErrors.UserExistError;
            }

            // Create user
            var userFactoryResult = _userFactory.CreateUser(username, email, password);
            if (userFactoryResult.IsError)
            {
                return userFactoryResult.Errors;
            }

            var user = userFactoryResult.Value;

            // Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Username, user.Email);

            return Result.Success;
        }
    }
}
