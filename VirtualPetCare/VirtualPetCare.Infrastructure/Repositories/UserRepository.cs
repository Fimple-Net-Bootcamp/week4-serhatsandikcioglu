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
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _dbSet;

        public UserRepository(AppDbContext appDbContext)
        {
            _dbSet = appDbContext.Set<User>();
        }

        public void Add(User user)
        {
            _dbSet.Add(user);
        }

        public User GetById(int id)
        {
           return _dbSet.Find(id);
        }
    }
}
