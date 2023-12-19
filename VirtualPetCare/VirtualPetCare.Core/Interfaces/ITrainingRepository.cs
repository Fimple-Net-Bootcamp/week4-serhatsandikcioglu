using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Core.Interfaces
{
    public interface ITrainingRepository
    {
        void Add(Training training);
        List<Training> GetAllByPetId(int petId);
    }
}
