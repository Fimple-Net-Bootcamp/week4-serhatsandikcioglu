using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.Entities
{
    public class HealthCondition :BaseEntity<int>
    {
        public string Condition { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
