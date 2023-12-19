using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Core.DTOs
{
    public class TrainingCreateDTO
    {
        public string Name { get; set; }
        public int PetId { get; set; }
    }
}
