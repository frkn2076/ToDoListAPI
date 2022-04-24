using Api.Models.Requests;
using FluentValidation;

namespace Api.Validations;

public class TaskRequestModelValidator : AbstractValidator<TaskRequestModel>
{
    public TaskRequestModelValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Deadline).NotNull();
        RuleFor(x => x.ListId).GreaterThan(0);
    }
}
