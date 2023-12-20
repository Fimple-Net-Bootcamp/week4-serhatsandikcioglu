using FluentValidation;
using System.Runtime.CompilerServices;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Core.Mapper;
using VirtualPetCare.Infrastructure.Database;
using VirtualPetCare.Infrastructure.Repositories;
using VirtualPetCare.Service.Interfaces;
using VirtualPetCare.Service.Validator;
using VirtualPetCare.Service;
using Microsoft.EntityFrameworkCore;

namespace VirtualPetCare.API
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddAplication (this IServiceCollection services) 
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IHealthConditionRepository, HealthConditionRepository>();
            services.AddScoped<IHealthConditionService, HealthConditionService>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ISocialInteractionRepository, SocialInteractionRepository>();
            services.AddScoped<ISocialInteractionService, SocialInteractionService>();
            services.AddSingleton<IValidator<ActivityCreateDTO>, ActivityCreateDTOValidator>();
            services.AddSingleton<IValidator<FoodCreateDTO>, FoodCreateDTOValidator>();
            services.AddSingleton<IValidator<HealthConditionCreateDTO>, HealthConditionCreateDTOValidator>();
            services.AddSingleton<IValidator<PetCreateDTO>, PetCreateDTOValidator>();
            services.AddSingleton<IValidator<PetUpdateDTO>, PetUpdateDTOValidator>();
            services.AddSingleton<IValidator<SocialInteractionCreateDTO>, SocialInteractionCreateDTOValidator>();
            services.AddSingleton<IValidator<TrainingCreateDTO>, TrainingCreateDTOValidator>();
            services.AddSingleton<IValidator<UserCreateDTO>, UserCreateDTOValidator>();


            return services;
        }
    }
}
