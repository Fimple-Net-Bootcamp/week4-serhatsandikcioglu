using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Service.Interfaces;
using VirtualPetCare.Shared.Model;

namespace VirtualPetCare.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainsRepository;
        private readonly IPetService _petService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<TrainingCreateDTO> _validator;

        public TrainingService(ITrainingRepository trainsRepository, IMapper mapper, IUnitOfWork unitOfWork, IPetService petService, IValidator<TrainingCreateDTO> validator)
        {
            _trainsRepository = trainsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _petService = petService;
            _validator = validator;
        }

        public async Task<CustomResponse<TrainingDTO>> Add(TrainingCreateDTO trainingCreateDTO)
        {
            var validateResult = _validator.Validate(trainingCreateDTO);
            var errorMesages = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
            var errorMesage = string.Join(",", errorMesages);
            if (!validateResult.IsValid)
            {
                return CustomResponse<TrainingDTO>.Fail(StatusCodes.Status400BadRequest,errorMesage);
            }
            bool petExist = _petService.IsExist(trainingCreateDTO.PetId);
            if (!petExist)
            {
                return CustomResponse<TrainingDTO>.Fail(StatusCodes.Status404NotFound,"Pet Not Found");
            }
            Training training = _mapper.Map<Training>(trainingCreateDTO);
            _trainsRepository.Add(training);
            _unitOfWork.SaveChanges();
            TrainingDTO trainingDTO = _mapper.Map<TrainingDTO>(training);
            return CustomResponse<TrainingDTO>.Success(StatusCodes.Status201Created,trainingDTO);
        }

        public async Task<CustomResponse<List<TrainingDTO>>> GetAllByPetId(int petId)
        {
           bool petExist =  _petService.IsExist(petId);
            if (!petExist)
            {
                return CustomResponse<List<TrainingDTO>>.Fail(StatusCodes.Status404NotFound,"Pet Not Found");
            }
            List<Training> trainings =  _trainsRepository.GetAllByPetId(petId);
            List<TrainingDTO> trainingDTOs = _mapper.Map<List<TrainingDTO>>(trainings);
            return CustomResponse<List<TrainingDTO>>.Success(StatusCodes.Status200OK, trainingDTOs); 
        }
    }
}
