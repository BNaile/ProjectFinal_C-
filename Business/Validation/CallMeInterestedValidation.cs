using Business.BaseMessage;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class CallMeInterestedValidation:AbstractValidator<CallMeInterested>
    {
        public CallMeInterestedValidation()
        {

            RuleFor(x => x.Details)
              .NotEmpty()
              .WithMessage(UIMessages.DEFAULT_NOT_EMPTY_MESSAGE)
              .MinimumLength(3)
              .WithMessage(UIMessages.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
              .MaximumLength(200)
              .WithMessage(UIMessages.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);


            RuleFor(x => x.CallMeId)
           .NotEmpty()
           .WithMessage(UIMessages.DEFAULT_NOT_EMPTY_MESSAGE);
        }

    }
}
