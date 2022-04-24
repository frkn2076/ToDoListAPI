using Api.Models.Requests;
using FluentValidation;

namespace Api.Validations;

public class ListRequestModelValidator : AbstractValidator<ListRequestModel>
{
    public ListRequestModelValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Date).NotNull();
    }
}
