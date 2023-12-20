using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
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
using VirtualPetCare.Shared.Model;

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

        public async Task<CustomResponse<HealthConditionDTO>>  GetByPetId(int petId)
        {
            HealthCondition healthCondition = _healthConditionRepository.GetByPetId(petId);
            HealthConditionDTO healthConditionDTO = _mapper.Map<HealthConditionDTO>(healthCondition);
            return CustomResponse<HealthConditionDTO>.Success(StatusCodes.Status200OK, healthConditionDTO);
        }
        public async Task<CustomResponse<NoContent>> Patch(int petId, JsonPatchDocument<HealthCondition> patchDoc)
        {
            HealthCondition healthCondition = _healthConditionRepository.GetByPetId(petId);
            if (healthCondition == null)
            {
                return CustomResponse<NoContent>.Fail(StatusCodes.Status404NotFound, "Pet Not Found");
            }
            
            patchDoc.ApplyTo(healthCondition);
            _unitOfWork.SaveChanges();
            return CustomResponse<NoContent>.Success(StatusCodes.Status200OK);
        }
    }
}
