using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Infrastructure.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VirtualPetCare.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly DbSet<Pet> _dbSet;

        public PetRepository(AppDbContext appDbContext)
        {
            _dbSet = appDbContext.Set<Pet>();
        }

        public void Add(Pet pet)
        {
            _dbSet.Add(pet);
        }

        public List<Pet> GetAll(string? sort, int page, int size)
        {
            IQueryable<Pet> query = _dbSet.AsQueryable();
            if (!string.IsNullOrWhiteSpace(sort))
            {
                var sortParts = sort.Split(' ');

                if (sortParts.Length == 2 && (sortParts[1].ToLower() == "asc" || sortParts[1].ToLower() == "desc"))
                {
                    string propertyName = sortParts[0].ToLower();

                    var validProperties = typeof(Pet).GetProperties().Select(p => p.Name.ToLower());

                    if (validProperties.Contains(propertyName))
                    {
                        query = query.AsQueryable().OrderBy(sort);
                    }
                    else
                    {
                        query = query.OrderBy(x => x.Id);
                    }
                }
            }
            int skipCount = (page - 1) * size;
            query = query.Skip(skipCount).Take(size);
            return query.ToList();
        }

        public Pet GetById(int id,bool relational = false)
        {
            if (relational)
            {
                return _dbSet.Include(x => x.Foods).Include(x => x.HealthCondition).Include(x => x.Activities).Where(x => x.Id == id).FirstOrDefault();
            }
           return _dbSet.Include(x=>x.Foods).Where(x=>x.Id == id).FirstOrDefault();
        }

        public void Update(Pet pet)
        {
            _dbSet.Update(pet);
        }
        public bool IsExist(int id)
        {
           return _dbSet.Any(x => x.Id == id);
        }
    }
}
