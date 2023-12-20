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
    public interface IUserService
    {
        Task<CustomResponse<UserDTO>> Add(UserCreateDTO userCreateDTO);
        Task<CustomResponse<UserDTO>> GetById(int id);
        Task<CustomResponse<List<PetDTO>>> GetPetsById(int id);
    }
}
