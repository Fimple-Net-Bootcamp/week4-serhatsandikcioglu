using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices;
using FluentValidation;
using VirtualPetCare.Shared.Model;

namespace VirtualPetCare.Service
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ActivityCreateDTO> _validator;
        public ActivityService(IActivityRepository activityRepository, IMapper mapper, IUnitOfWork unitOfWork, IPetRepository petRepository, IValidator<ActivityCreateDTO> validator)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _petRepository = petRepository;
            _validator = validator;
        }

        public async Task<CustomResponse<ActivityDTO>> Add(ActivityCreateDTO activityCreateDTO)
        {
            var validateResult = _validator.Validate(activityCreateDTO);
            var errorMesages = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
            var errorMesage = string.Join(",", errorMesages);
            if (!validateResult.IsValid)
            {
                return CustomResponse<ActivityDTO>.Fail(StatusCodes.Status400BadRequest, errorMesage);
            }
            bool petExist = _petRepository.IsExist(activityCreateDTO.PetId);
            if (!petExist)
            {
                return CustomResponse<ActivityDTO>.Fail(StatusCodes.Status404NotFound,"Pet Id Not Found");
            }
            Activity activity = _mapper.Map<Activity>(activityCreateDTO);
            _activityRepository.Add(activity);
            _unitOfWork.SaveChanges();
            ActivityDTO activityDTO = _mapper.Map<ActivityDTO>(activity);
            return CustomResponse<ActivityDTO>.Success(StatusCodes.Status200OK,activityDTO);
            
        }

        public async Task<CustomResponse<List<ActivityDTO>>> GetById(int petId)
        {
            bool petExist = _petRepository.IsExist(petId);
            if (!petExist)
            {
                return CustomResponse<List<ActivityDTO>>.Fail(StatusCodes.Status404NotFound,"Pet Id Not Found");
            }
           List<Activity> activities = _activityRepository.GetById(petId);
            List<ActivityDTO> activityDTOs = _mapper.Map<List<ActivityDTO>>(activities);
            return CustomResponse<List<ActivityDTO>>.Success(StatusCodes.Status200OK,activityDTOs);
        }
    }
}
