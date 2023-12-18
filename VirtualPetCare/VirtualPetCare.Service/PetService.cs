using AutoMapper;
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

namespace VirtualPetCare.Service
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PetService(IPetRepository petRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _petRepository = petRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PetDTO Add(PetCreateDTO petCreateDTO)
        {
            Pet pet = _mapper.Map<Pet>(petCreateDTO);
            _petRepository.Add(pet);
            _unitOfWork.SaveChanges();
            PetDTO petDTO = _mapper.Map<PetDTO>(pet);
            return petDTO;
        }

        public List<PetDTO> GetAll(string? sort, int page, int size)
        {
            List<Pet> pets = _petRepository.GetAll(sort, page,size);
            List<PetDTO> petDTOs = _mapper.Map<List<PetDTO>>(pets);
            return petDTOs;
        }

        public PetDTO GetById(int id , bool relational)
        {
            Pet pet = _petRepository.GetById(id,relational);
            PetDTO petDTO = _mapper.Map<PetDTO>(pet);
            return petDTO;
        }

        public bool IsExist(int id)
        {
            return _petRepository.IsExist(id);
        }

        public void Update(int id, PetUpdateDTO petUpdateDTO)
        {
            Pet pet = _mapper.Map<Pet>(petUpdateDTO);
            pet.Id = id;
            _petRepository.Update(pet);
            _unitOfWork.SaveChanges();
        }
    }
}
