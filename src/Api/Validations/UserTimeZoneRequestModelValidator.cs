using Api.Models.Requests;
using FluentValidation;

namespace Api.Validations;

public class UserTimeZoneRequestModelValidator : AbstractValidator<UserTimeZoneRequestModel>
{
    public UserTimeZoneRequestModelValidator()
    {
        RuleFor(x => x.TimeZone).InclusiveBetween(-12, 14);
    }
}
