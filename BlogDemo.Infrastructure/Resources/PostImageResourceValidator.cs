using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Core.Entities;
using FluentValidation;

namespace BlogDemo.Infrastructure.Resources
{
    public class PostImageResourceValidator : AbstractValidator<PostImageResource>
    {
        public PostImageResourceValidator()
        {
            RuleFor(x => x.FileName)
                .NotNull()
                .WithName("File Name")
                .WithMessage("required|{PropertyName} is required!")
                .MaximumLength(100)
                .WithMessage("maxlength|{PropertyName} max length is{maxLength}");
        }
    }
}
