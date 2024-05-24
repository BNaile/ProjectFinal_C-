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
    public class ServicePackageDescriptionValidation:AbstractValidator<ServicePackageDescription>
    {
        public ServicePackageDescriptionValidation()
        {
            RuleFor(x => x.Description)
                    .MinimumLength(3)
                    .WithMessage(UIMessages.DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE)
                    .MaximumLength(1000)
                    .WithMessage(UIMessages.DEFAULT_MAXIMUM_SYMBOL_COUNT_2000_MESSAGE)
                    .NotEmpty()
                    .WithMessage(UIMessages.DEFAULT_NOT_EMPTY_MESSAGE);
        }
    }
}
