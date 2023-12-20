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
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<FoodCreateDTO> _validator;

        public FoodService(IFoodRepository foodRepository, IUnitOfWork unitOfWork, IMapper mapper, IPetRepository petRepository, IValidator<FoodCreateDTO> validator)
        {
            _foodRepository = foodRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _petRepository = petRepository;
            _validator = validator;
        }

        public async Task<CustomResponse<FoodDTO>> Add(int petId , FoodCreateDTO foodCreateDTO)
        {
            var validateResult = _validator.Validate(foodCreateDTO);
            var errorMesages = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
            var errorMesage = string.Join(",", errorMesages);
            if (!validateResult.IsValid)
            {
                return CustomResponse<FoodDTO>.Fail(StatusCodes.Status400BadRequest, errorMesage);
            }
            Pet pet = _petRepository.GetById(petId, false);
            if (pet == null)
            {
                return CustomResponse<FoodDTO>.Fail(StatusCodes.Status404NotFound, "Pet Not Found");
            }
            Food food = _mapper.Map<Food>(foodCreateDTO);
            if (pet.Foods == null)
            {
                pet.Foods  = new List<Food>();
            }
                pet.Foods.Add(food);
            _foodRepository.Add(food);
            _unitOfWork.SaveChanges();
            FoodDTO foodDTO = _mapper.Map<FoodDTO>(food);
            return CustomResponse<FoodDTO>.Success(StatusCodes.Status201Created,foodDTO);
        }

        public async Task<CustomResponse<List<FoodDTO>>> GetAll(string? sort, int page, int size)
        {
           List<Food> foods = _foodRepository.GetAll(sort, page, size);
            List<FoodDTO> foodDTOs = _mapper.Map<List<FoodDTO>>(foods);
            return CustomResponse<List<FoodDTO>>.Success(StatusCodes.Status200OK, foodDTOs);
        }
    }
}
