using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Shared.Model;

namespace VirtualPetCare.Service.Interfaces
{
    public interface IFoodService
    {
        Task<CustomResponse<List<FoodDTO>>> GetAll(string? sort, int page, int size);
        Task<CustomResponse<FoodDTO>> Add(int petId, FoodCreateDTO foodCreateDTO);
    }
}
