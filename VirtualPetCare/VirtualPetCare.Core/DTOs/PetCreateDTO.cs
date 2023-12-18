using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Core.DTOs
{
    public class PetCreateDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }
        public HealthConditionCreateDTO HealthCondition { get; set; }
    }
}
