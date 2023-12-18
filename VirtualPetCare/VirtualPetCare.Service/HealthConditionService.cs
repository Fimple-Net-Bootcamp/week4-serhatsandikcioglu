using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.Service
{
    public class HealthConditionService : IHealthConditionService
    {
        private readonly IHealthConditionRepository _healthConditionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HealthConditionService(IHealthConditionRepository healthConditionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _healthConditionRepository = healthConditionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public HealthConditionDTO GetById(int petId)
        {
            HealthCondition healthCondition = _healthConditionRepository.GetById(petId);
            HealthConditionDTO healthConditionDTO = _mapper.Map<HealthConditionDTO>(healthCondition);
            return healthConditionDTO;
        }
        public void Patch(int id, JsonPatchDocument<HealthCondition> patchDoc)
        {
            HealthCondition healthCondition = _healthConditionRepository.GetById(id);
            patchDoc.ApplyTo(healthCondition);
            _unitOfWork.SaveChanges();
        }
    }
}
