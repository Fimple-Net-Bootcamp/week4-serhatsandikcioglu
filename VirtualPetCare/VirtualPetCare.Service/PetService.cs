using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<PetCreateDTO> _createValidator;
        private readonly IValidator<PetUpdateDTO> _updateValidator;

        public PetService(IPetRepository petRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<PetCreateDTO> createValidator, IValidator<PetUpdateDTO> updateValidator, IUserRepository userRepository)
        {
            _petRepository = petRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _userRepository = userRepository;
        }

        public async Task<CustomResponse<PetDTO>> Add(PetCreateDTO petCreateDTO)
        {
            var validateResult = _createValidator.Validate(petCreateDTO);
            var errorMesages = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
            var errorMesage = string.Join(",", errorMesages);
            if (!validateResult.IsValid)
            {
                return CustomResponse<PetDTO>.Fail(StatusCodes.Status400BadRequest,errorMesage);
            }
            bool userExist = _userRepository.IsExist(petCreateDTO.UserId);
            if (!userExist)
            {
                return CustomResponse<PetDTO>.Fail(StatusCodes.Status404NotFound,"User Not Found");
            }
            Pet pet = _mapper.Map<Pet>(petCreateDTO);
            _petRepository.Add(pet);
            _unitOfWork.SaveChanges();
            PetDTO petDTO = _mapper.Map<PetDTO>(pet);
            return CustomResponse<PetDTO>.Success(StatusCodes.Status201Created, petDTO);
        }

        public async Task<CustomResponse<List<PetDTO>>> GetAll(string? sort, int page, int size)
        {
            List<Pet> pets = _petRepository.GetAll(sort, page,size);
            List<PetDTO> petDTOs = _mapper.Map<List<PetDTO>>(pets);
            return CustomResponse<List<PetDTO>>.Success(StatusCodes.Status200OK,petDTOs);
        }

        public async Task<CustomResponse<PetDTO>> GetById(int id , bool relational)
        {
            Pet pet = _petRepository.GetById(id,relational);
            if (pet == null)
            {
                return CustomResponse<PetDTO>.Fail(StatusCodes.Status404NotFound, "Pet Not Found");
            }
            PetDTO petDTO = _mapper.Map<PetDTO>(pet);
            return CustomResponse<PetDTO>.Success(StatusCodes.Status200OK, petDTO);
        }

        public async Task<CustomResponse<NoContent>> Update(int id, PetUpdateDTO petUpdateDTO)
        {
            var validateResult = _updateValidator.Validate(petUpdateDTO);
            var errorMesages = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
            var errorMesage = string.Join(",", errorMesages);
            if (!validateResult.IsValid)
            {
                return CustomResponse<NoContent>.Fail(StatusCodes.Status400BadRequest,errorMesage);
            }
            bool petExist = _petRepository.IsExist(id);
            if (!petExist)
            {
                return CustomResponse<NoContent>.Fail(StatusCodes.Status404NotFound, "Pet Not Found");
            }
            bool userExist = _userRepository.IsExist(petUpdateDTO.UserId);
            if (!userExist)
            {
                return CustomResponse<NoContent>.Fail(StatusCodes.Status404NotFound, "User Not Found");
            }
            Pet pet = _petRepository.GetById(id , false);
            _mapper.Map(petUpdateDTO, pet);
            _petRepository.Update(pet);
            _unitOfWork.SaveChanges();
            return CustomResponse<NoContent>.Success(StatusCodes.Status200OK);
        }
    }
}
