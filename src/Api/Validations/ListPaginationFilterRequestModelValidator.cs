using Api.Models.Requests;
using FluentValidation;

namespace Api.Validations;

public class ListPaginationFilterRequestModelValidator : AbstractValidator<ListPaginationFilterRequestModel>
{
    public ListPaginationFilterRequestModelValidator()
    {
        RuleFor(x => x).Must(x => x.DateMin < x.DateMax).WithMessage("Datemin must be less than datemax");
        RuleFor(x => x.Title).MaximumLength(20);
    }
}
