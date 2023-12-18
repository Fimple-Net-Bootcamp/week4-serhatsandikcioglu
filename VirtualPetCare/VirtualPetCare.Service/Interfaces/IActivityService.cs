using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Service.CustomResponse;

namespace VirtualPetCare.Service.Interfaces
{
    public interface IActivityService
    {
        Task<CustomResponse<ActivityDTO>> Add(ActivityCreateDTO activityCreateDTO);
        Task<CustomResponse<List<ActivityDTO>>> GetById(int petId);
    }
}
