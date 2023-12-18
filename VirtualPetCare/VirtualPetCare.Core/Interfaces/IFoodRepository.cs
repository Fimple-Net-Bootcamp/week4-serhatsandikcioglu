using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Core.Interfaces
{
    public interface IFoodRepository
    {
        List<Food> GetAll(string? sort, int page, int size);
        void Add(Food food);
    }
}
