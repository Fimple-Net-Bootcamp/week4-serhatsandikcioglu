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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public UserDTO Add(UserCreateDTO userCreateDTO)
        {
            User user = _mapper.Map<User>(userCreateDTO);
            _userRepository.Add(user);
            _unitOfWork.SaveChanges();
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public UserDTO GetById(int id)
        {
            User user = _userRepository.GetById(id);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}
