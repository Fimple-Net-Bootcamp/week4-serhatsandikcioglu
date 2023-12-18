using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Core.Interfaces
{
    public interface IActivityRepository
    {
        void Add(Activity activity);
        List<Activity> GetById(int petId);
    }
}
