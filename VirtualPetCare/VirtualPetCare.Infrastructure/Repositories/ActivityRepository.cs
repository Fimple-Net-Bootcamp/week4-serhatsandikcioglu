using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Infrastructure.Database;

namespace VirtualPetCare.Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DbSet<Activity> _dbSet;

        public ActivityRepository(AppDbContext appDbContext)
        {
            _dbSet = appDbContext.Set<Activity>();
        }

        public void Add(Activity activity)
        {
            _dbSet.Add(activity);
        }

        public List<Activity> GetById(int petId)
        {
            return _dbSet.Where(x => x.PetId == petId).ToList();
        }
    }
}
