using FluentValidation;

namespace BlogDemo.Infrastructure.Resources
{
    public class PostAddOrUpdateResourceValidator<T>: AbstractValidator<T> where T : PostAddOrUpdateResource
    {
        public PostAddOrUpdateResourceValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .WithName("TITLE")
                .WithMessage("required|{PropertyName} is required")
                .MaximumLength(50)
                .WithMessage("maxLength|{PropertyName} max length is 50.");

            RuleFor(x => x.Body)
                .NotNull()
                .WithName("BODY")
                .WithMessage("required|{PropertyName} is required")
                .MinimumLength(50)
                .WithMessage("minLength|{PropertyName} minimum length is 50.");
        }

    }
}
