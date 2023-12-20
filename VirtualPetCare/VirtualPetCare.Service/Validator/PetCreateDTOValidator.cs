using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;

namespace VirtualPetCare.Service.Validator
{
    public class PetCreateDTOValidator : AbstractValidator<PetCreateDTO>
    {
        public PetCreateDTOValidator() 
        {
            RuleFor(x => x.Age).NotNull().WithMessage("cannot be empty");
            RuleFor(x => x.Name).NotNull().WithMessage("cannot be empty").MaximumLength(50).WithMessage("The number of characters must be less than 50");
            RuleFor(x => x.HealthCondition.Condition).NotNull().WithMessage("cannot be empty").MaximumLength(50).WithMessage("The number of characters must be less than 50");
            RuleFor(x => x.UserId).NotNull().WithMessage("cannot be empty");
        }
    }
}
