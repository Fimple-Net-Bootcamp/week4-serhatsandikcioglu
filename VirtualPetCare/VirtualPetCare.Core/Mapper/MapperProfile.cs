using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Core.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Activity, ActivityCreateDTO>().ReverseMap();
            CreateMap<Activity, ActivityDTO>().ReverseMap();
            CreateMap<Food , FoodCreateDTO>().ReverseMap();
            CreateMap<Food, FoodDTO>().ReverseMap();
            CreateMap<HealthCondition, HealthConditionDTO>().ReverseMap();
            CreateMap<HealthCondition, HealthConditionCreateDTO>().ReverseMap();
            CreateMap<Pet, PetDTO>().ReverseMap();
            CreateMap<Pet, PetCreateDTO>().ReverseMap();
            CreateMap<Pet, PetUpdateDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Training, TrainingCreateDTO>().ReverseMap();
            CreateMap<Training, TrainingDTO>().ReverseMap();
            CreateMap<SocialInteraction, SocialInteractionDTO>().ReverseMap();
            CreateMap<SocialInteraction, SocialInteractionCreateDTO>().ReverseMap();
        }
    }
}
