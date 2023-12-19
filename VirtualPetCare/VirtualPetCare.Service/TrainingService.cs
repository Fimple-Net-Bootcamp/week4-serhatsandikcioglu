using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.DTOs.CustomResponse;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Service.CustomResponse;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainsRepository;
        private readonly IPetService _petService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TrainingService(ITrainingRepository trainsRepository, IMapper mapper, IUnitOfWork unitOfWork, IPetService petService)
        {
            _trainsRepository = trainsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _petService = petService;
        }

        public async Task<CustomResponse<TrainingDTO>> Add(TrainingCreateDTO trainingCreateDTO)
        {
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
