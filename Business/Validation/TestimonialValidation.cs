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
    public class TestimonialValidation: AbstractValidator<Testimonial>
    {
        public TestimonialValidation()
        {
            RuleFor(x => x.Name)
       .NotEmpty()
         .WithMessage(UIMessages.DEFAULT_NOT_EMPTY_MESSAGE)
       .MinimumLength(3)
         .WithMessage(UIMessages.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
       .MaximumLength(100)
         .WithMessage(UIMessages.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);

            RuleFor(x => x.Surname)
     .NotEmpty()
       .WithMessage(UIMessages.DEFAULT_NOT_EMPTY_MESSAGE)
     .MinimumLength(3)
       .WithMessage(UIMessages.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
     .MaximumLength(100)
       .WithMessage(UIMessages.DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE);
        }
    }
}
