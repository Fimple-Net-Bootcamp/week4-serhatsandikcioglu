using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Service.CustomResponse;

namespace VirtualPetCare.Service.Interfaces
{
    public interface ISocialInteractionService
    {
        Task<CustomResponse<List<SocialInteractionDTO>>> GetAllByPetId(int petId);
        Task<CustomResponse<SocialInteractionDTO>> Create(SocialInteractionCreateDTO socialInteractionCreateDTO);
    }
}
