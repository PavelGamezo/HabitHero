using FluentValidation;
using HabitHero.Application.Users.Queries.GetProfile;

namespace HabitHero.Application.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryValidator : AbstractValidator<GetUserProfileQuery>
    {
        public GetUserProfileQueryValidator()
        {
            RuleFor(query => query.UserId)
                .NotEmpty().WithMessage("Identifier must be not empty");
        }
    }
}
