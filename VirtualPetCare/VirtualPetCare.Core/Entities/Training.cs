using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.Entities
{
    public class Training : BaseEntity<int>
    {
        public string Name { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
