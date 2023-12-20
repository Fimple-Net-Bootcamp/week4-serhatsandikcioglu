using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Shared.Model;

namespace VirtualPetCare.Service.Interfaces
{
    public interface ITrainingService
    {
        Task<CustomResponse<TrainingDTO>> Add(TrainingCreateDTO trainingCreateDTO);
        Task<CustomResponse<List<TrainingDTO>>> GetAllByPetId(int petId);
    }
}
