using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Service.Interfaces
{
    public interface IUserService
    {
        UserDTO Add(UserCreateDTO userCreateDTO);
        UserDTO GetById(int id);
        List<PetDTO> GetAllPetById(int id);
    }
}
