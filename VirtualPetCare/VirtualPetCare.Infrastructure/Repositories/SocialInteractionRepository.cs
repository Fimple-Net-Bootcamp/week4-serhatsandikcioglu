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
    public class SocialInteractionRepository : ISocialInteractionRepository
    {
        private readonly DbSet<SocialInteraction> _dbSet;

        public SocialInteractionRepository(AppDbContext appDbContext)
        {
            _dbSet = appDbContext.Set<SocialInteraction>();
        }

        public void Add(SocialInteraction socialInteraction)
        {
            _dbSet.Add(socialInteraction);
        }
    }
}
