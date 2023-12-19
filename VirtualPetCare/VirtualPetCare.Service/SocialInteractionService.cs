using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Service.CustomResponse;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.Service
{
    public class SocialInteractionService : ISocialInteractionService
    {
        private readonly ISocialInteractionRepository _socialInteractionRepository;
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SocialInteractionService(ISocialInteractionRepository socialInteractionRepository, IMapper mapper, IUnitOfWork unitOfWork, IPetRepository petRepository)
        {
            _socialInteractionRepository = socialInteractionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _petRepository = petRepository;
        }

        public async Task<CustomResponse<SocialInteractionDTO>> Create(SocialInteractionCreateDTO socialInteractionCreateDTO)
        {
            SocialInteraction socialInteraction = _mapper.Map<SocialInteraction>(socialInteractionCreateDTO);
            _socialInteractionRepository.Add(socialInteraction);
            _unitOfWork.SaveChanges();
            SocialInteractionDTO socialInteractionDTO = _mapper.Map<SocialInteractionDTO>(socialInteraction);
            return CustomResponse<SocialInteractionDTO>.Success(StatusCodes.Status201Created, socialInteractionDTO);
        }

        public async Task<CustomResponse<List<SocialInteractionDTO>>> GetAllByPetId(int petId)
        {
            bool petExist = _petRepository.IsExist(petId);
            if (!petExist)
            {
                return CustomResponse<List<SocialInteractionDTO>>.Fail(StatusCodes.Status404NotFound, "Pet Not Found");
            }
           List<SocialInteraction> socialInteractions = _petRepository.GetSocialInteractions(petId);
            List<SocialInteractionDTO> socialInteractionDTOs = _mapper.Map<List<SocialInteractionDTO>>(socialInteractions);
            return CustomResponse<List<SocialInteractionDTO>>.Success(StatusCodes.Status200OK, socialInteractionDTOs);
        }
    }
}
