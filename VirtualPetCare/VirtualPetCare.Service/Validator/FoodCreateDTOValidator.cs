using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;

namespace VirtualPetCare.Service.Validator
{
    public class FoodCreateDTOValidator : AbstractValidator<FoodCreateDTO>
    {
        public FoodCreateDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("cannot be empty").MaximumLength(50).WithMessage("The number of characters must be less than 50");
        }
    }
}
