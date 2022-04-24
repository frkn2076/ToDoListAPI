using Api.Models.Requests;
using FluentValidation;

namespace Api.Validations;

public class RegisterRequestModelValidator : AbstractValidator<RegisterRequestModel>
{
    public RegisterRequestModelValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().Length(4, 40);
        RuleFor(x => x.Password).NotEmpty().Length(4, 20);
    }
}
