using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.Entities
{
    public class Food : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
