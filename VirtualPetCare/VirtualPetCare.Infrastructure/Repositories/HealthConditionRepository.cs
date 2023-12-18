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
    public class HealthConditionRepository : IHealthConditionRepository
    {
        private readonly DbSet<HealthCondition> _dbSet;

        public HealthConditionRepository(AppDbContext appDbContext)
        {
            _dbSet = appDbContext.Set<HealthCondition>();
        }

        public HealthCondition GetById(int petId)
        {
            return _dbSet.Where(x => x.PetId == petId).FirstOrDefault();
        }
    }
}
