using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Service.Interfaces
{
    public interface IHealthConditionService
    {
        HealthConditionDTO GetById(int id);
        void Patch(int id, JsonPatchDocument<HealthCondition> patchDoc);
    }
}
