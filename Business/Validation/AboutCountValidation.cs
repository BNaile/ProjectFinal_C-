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
    public class AboutCountValidation:AbstractValidator<AboutCount>
    {
        public AboutCountValidation()
        {

            RuleFor(x => x.Count)
              .NotEmpty()
              .WithMessage(UIMessages.DEFAULT_NOT_EMPTY_MESSAGE);
        }
    }
}
