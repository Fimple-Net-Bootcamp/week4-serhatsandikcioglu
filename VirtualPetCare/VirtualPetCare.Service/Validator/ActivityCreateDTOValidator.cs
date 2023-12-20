using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Service.Validator
{
    public class ActivityCreateDTOValidator : AbstractValidator<ActivityCreateDTO>
    {
        public ActivityCreateDTOValidator() 
        {
            RuleFor(x => x.Name).NotNull().WithMessage("cannot be empty").MaximumLength(50).WithMessage("The number of characters must be less than 50");
            RuleFor(x => x.PetId).NotNull().WithMessage("cannot be empty");
        }
    }
}
