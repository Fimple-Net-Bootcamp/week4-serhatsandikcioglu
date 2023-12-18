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

namespace VirtualPetCare.Service
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FoodService(IFoodRepository foodRepository, IUnitOfWork unitOfWork, IMapper mapper, IPetRepository petRepository)
        {
            _foodRepository = foodRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _petRepository = petRepository;
        }

        public FoodDTO Add(int petId , FoodCreateDTO foodCreateDTO)
        {
            Pet pet = _petRepository.GetById(petId, false);
            Food food = _mapper.Map<Food>(foodCreateDTO);
                pet.Foods.Add(food);
            _foodRepository.Add(food);
            _unitOfWork.SaveChanges();
            FoodDTO foodDTO = _mapper.Map<FoodDTO>(food);
            return foodDTO;
        }

        public List<FoodDTO> GetAll(string? sort, int page, int size)
        {
           List<Food> foods = _foodRepository.GetAll(sort, page, size);
            List<FoodDTO> foodDTOs = _mapper.Map<List<FoodDTO>>(foods);
            return foodDTOs;
        }
    }
}
