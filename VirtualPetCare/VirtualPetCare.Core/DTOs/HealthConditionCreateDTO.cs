using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Core.DTOs
{
    public class HealthConditionCreateDTO
    {
        public string Condition { get; set; }
    }
}
