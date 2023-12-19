using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.Entities
{
    public class Pet : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public HealthCondition HealthCondition { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Food> Foods { get; set; }
        public List<Training> Training { get; set; }
        public List<SocialInteraction> SocialInteractions { get; set; }
    }
}
