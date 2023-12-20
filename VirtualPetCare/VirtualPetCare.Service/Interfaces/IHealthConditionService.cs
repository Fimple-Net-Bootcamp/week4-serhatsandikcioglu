using Microsoft.AspNetCore.JsonPatch;
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
    public interface IHealthConditionService
    {
        Task<CustomResponse<HealthConditionDTO>> GetByPetId(int petId);
        Task<CustomResponse<NoContent>> Patch(int petId, JsonPatchDocument<HealthCondition> patchDoc);
    }
}
