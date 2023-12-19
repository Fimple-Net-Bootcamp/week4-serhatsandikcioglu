using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Infrastructure.Database;

namespace VirtualPetCare.Infrastructure.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly DbSet<Training> _dbSet;

        public TrainingRepository(AppDbContext appDbContext)
        {
            _dbSet = appDbContext.Set<Training>();
        }

        public void Add(Training training)
        {
            _dbSet.Add(training);
        }

        public List<Training> GetAllByPetId(int petId)
        {
           return _dbSet.Where(x => x.PetId == petId).ToList();
        }
    }
}
