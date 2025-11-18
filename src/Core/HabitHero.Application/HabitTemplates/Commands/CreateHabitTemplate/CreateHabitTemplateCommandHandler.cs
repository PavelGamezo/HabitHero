using ErrorOr;
using HabitHero.Application.Common.CQRS.Commands;
using HabitHero.Application.Common.Errors;
using HabitHero.Application.Common.Persistence;
using HabitHero.Domain.Common.Factory;
using HabitHero.Domain.Users.Enums;

namespace HabitHero.Application.HabitTemplates.Commands.CreateHabitTemplate
{
    public class CreateHabitTemplateCommandHandler : ICommandHandler<CreateHabitTemplateCommand, ErrorOr<Success>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHabitTemplateRepository _habitTemplateRepository;
        private readonly IHabitTemplateFactory _habitTemplateFactory;

        public CreateHabitTemplateCommandHandler(IUserRepository userRepository,
            IHabitTemplateRepository _habitTemplateRepository,
            IHabitTemplateFactory habitTemplateFactory)
        {
            _userRepository = userRepository;
            _habitTemplateRepository = habitRepository;
            _habitTemplateFactory = habitTemplateFactory;
        }

        public async Task<ErrorOr<Success>> Handle(CreateHabitTemplateCommand request, CancellationToken cancellationToken)
        {
            var (title, description, frequency, category, userId) = request;

            var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
            if (user is null)
            {
                return UserApplicationErrors.NotFoundUserError;
            }

            if (!user.Roles.Any(role => role.Name == RolesEnum.Admin.ToString()))
            {
                return HabitApplicationErrors.NoAccessError;
            }

            var habitFactoryResult = _habitTemplateFactory.CreateHabitTemplate(
                title,
                description,
                frequency,
                category);

            if (habitFactoryResult.IsError)
            {
                return habitFactoryResult.Errors;
            }

            return Result.Success;
        }
    }
}
