using ErrorOr;
using HabitHero.Application.Common.CQRS.Commands;
using HabitHero.Application.Common.Errors;
using HabitHero.Application.Common.Persistence;
using HabitHero.Application.Common.Services.Authentication;
using HabitHero.Domain.Common.Factory;
using HabitHero.Domain.Users.Enums;

namespace HabitHero.Application.Users.Commands.RegisterUser
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, ErrorOr<Success>>
    {
        private readonly IUserRepository _userRepository; 
        private readonly IRoleRepository _roleRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserFactory _userFactory;

        public RegisterUserCommandHandler(IUserRepository userRepository,
            IRoleRepository roleRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IUserFactory userFactory)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
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

            var role = await _roleRepository.GetRoleById((int)RolesEnum.User, cancellationToken);
            if (role is null)
            {
                return UserApplicationErrors.NotFoundRoleError;
            }

            user.AddRole(role);

            // Add User to Database
            _userRepository.AddUser(user);
            await _userRepository.SaveAsync(cancellationToken);

            // Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Username, user.Email);

            return Result.Success;
        }
    }
}
