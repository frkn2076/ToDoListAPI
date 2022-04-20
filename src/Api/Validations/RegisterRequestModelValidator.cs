using Api.Models.Requests;
using FluentValidation;

namespace Api.Validations;

public class RegisterRequestModelValidator : AbstractValidator<RegisterRequestModel>
{
    public RegisterRequestModelValidator()
    {
        RuleFor(x => x.UserName).NotEmpty();
        RuleFor(x => x.UserName).Length(4, 20);
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Password).Length(4, 20);
    }
}
