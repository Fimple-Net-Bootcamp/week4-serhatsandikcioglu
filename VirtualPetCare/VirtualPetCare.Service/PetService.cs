using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<PetCreateDTO> _createValidator;
        private readonly IValidator<PetUpdateDTO> _updateValidator;

        public PetService(IPetRepository petRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<PetCreateDTO> createValidator, IValidator<PetUpdateDTO> updateValidator)
        {
            _petRepository = petRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
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

        public bool IsExist(int id)
        {
            return _petRepository.IsExist(id);
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
            bool petExist = IsExist(id);
            if (!petExist)
            {
                return CustomResponse<NoContent>.Fail(StatusCodes.Status404NotFound, "Pet Not Found");
            }
            Pet pet = _mapper.Map<Pet>(petUpdateDTO);
            pet.Id = id;
            _petRepository.Update(pet);
            _unitOfWork.SaveChanges();
            return CustomResponse<NoContent>.Success(StatusCodes.Status200OK);
        }
    }
}
