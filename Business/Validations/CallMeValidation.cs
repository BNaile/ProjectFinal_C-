using Business.BaseMessage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class CallMeValidation:AbstractValidator<CallMe>
{
    public CallMeValidation()
    {
        RuleFor(x => x.Description)
        .MinimumLength(3)
           .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
        .MaximumLength(2000)
           .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_2000_MESSAGE)
        .NotEmpty()
           .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);

        RuleFor(x => x.Title)
           .NotEmpty()
           .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
           .MinimumLength(3)
           .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
           .MaximumLength(150)
           .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);

        RuleFor(x => x.Name)
        .NotEmpty()
        .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
        .MinimumLength(3)
        .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
        .MaximumLength(150)
        .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);

        RuleFor(x => x.Email)
        .NotEmpty()
        .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
        .MinimumLength(3)
        .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
        .MaximumLength(150)
        .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);

        RuleFor(x => x.ServiceId)
         .NotEmpty()
         .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);

        RuleFor(x => x.Phone)
   .NotEmpty()
   .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
   .MinimumLength(3)
   .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
   .MaximumLength(13)
   .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);

        RuleFor(x => x.ServiceCategoryName)
     .NotEmpty()
     .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
     .MinimumLength(3)
     .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
     .MaximumLength(150)
     .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);

    }
}
