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
    public interface IPetService
    {
        Task<CustomResponse<List<PetDTO>>> GetAll(string? sort, int page, int size);
        Task<CustomResponse<PetDTO>> GetById(int id, bool relational);
        Task<CustomResponse<PetDTO>> Add(PetCreateDTO petCreateDTO);
        Task<CustomResponse<NoContent>> Update(int id, PetUpdateDTO petUpdateDTO);
    }
}
