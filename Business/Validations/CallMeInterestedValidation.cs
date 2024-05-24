using Business.BaseMessage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class CallMeInterestedValidation:AbstractValidator<CallMeInterested>
    {
        public CallMeInterestedValidation()
        {
            RuleFor(x => x.ServiceId)
            .NotEmpty()
            .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE);

            RuleFor(x => x.Details)
           .NotEmpty()
           .WithMessage(UIMessage.DEFAULT_NOT_EMPTY_MESSAGE)
           .MinimumLength(3)
           .WithMessage(UIMessage.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
           .MaximumLength(150)
           .WithMessage(UIMessage.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);
        }
    }
}
