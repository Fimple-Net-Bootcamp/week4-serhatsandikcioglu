using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Service.Interfaces
{
    public interface IFoodService
    {
        List<FoodDTO> GetAll(string? sort, int page, int size);
        FoodDTO Add(int petId, FoodCreateDTO foodCreateDTO);
    }
}
