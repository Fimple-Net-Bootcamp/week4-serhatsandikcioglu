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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UserCreateDTO> _validator;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UserCreateDTO> validator)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CustomResponse<UserDTO>>  Add(UserCreateDTO userCreateDTO)
        {
            var validateResult = _validator.Validate(userCreateDTO);
            var errorMesages = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
            var errorMesage = string.Join(",", errorMesages);
            if (!validateResult.IsValid)
            {
                return CustomResponse<UserDTO>.Fail(StatusCodes.Status400BadRequest, errorMesage);
            }
            User user = _mapper.Map<User>(userCreateDTO);
            _userRepository.Add(user);
            _unitOfWork.SaveChanges();
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return CustomResponse<UserDTO>.Success(StatusCodes.Status201Created, userDTO);
        }

        public async Task<CustomResponse<UserDTO>>  GetById(int id)
        {
            User user = _userRepository.GetById(id);
            if (user == null)
            {
                return CustomResponse<UserDTO>.Fail(StatusCodes.Status404NotFound, "User Not Found");
            }
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return CustomResponse<UserDTO>.Success(StatusCodes.Status200OK, userDTO);
        }
        public async Task<CustomResponse<List<PetDTO>>> GetPetsById(int id)
        {
            bool userExist = _userRepository.IsExist(id);
            if (!userExist)
            {
                return CustomResponse<List<PetDTO>>.Fail(StatusCodes.Status404NotFound, "User Not Found");
            }
            List<Pet> pets = _userRepository.GetPetsById(id);
            List<PetDTO> petDTOs = _mapper.Map<List<PetDTO>>(pets);
            return CustomResponse<List<PetDTO>>.Success(StatusCodes.Status200OK, petDTOs);
        }
    }
}
