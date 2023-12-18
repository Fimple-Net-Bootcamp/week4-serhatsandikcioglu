using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Service.Interfaces
{
    public interface IPetService
    {
        public List<PetDTO> GetAll(string? sort, int page, int size);
        PetDTO GetById(int id);
        public PetDTO Add(PetCreateDTO petCreateDTO);
        void Update(int id , PetUpdateDTO petUpdateDTO);
        bool IsExist(int id);
    }
}
