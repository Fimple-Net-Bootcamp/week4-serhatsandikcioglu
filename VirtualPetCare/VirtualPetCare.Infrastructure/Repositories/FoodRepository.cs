using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Infrastructure.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VirtualPetCare.Infrastructure.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly DbSet<Food> _dbSet;

        public FoodRepository(AppDbContext appDbContext)
        {
            _dbSet = appDbContext.Set<Food>();
        }

        public void Add(Food food)
        {
            _dbSet.Add(food);
        }

        public List<Food> GetAll(string? sort, int page, int size)
        {
            IQueryable<Food> query = _dbSet.AsQueryable();
            if (!string.IsNullOrWhiteSpace(sort))
            {
                var sortParts = sort.Split(' ');

                if (sortParts.Length == 2 && (sortParts[1].ToLower() == "asc" || sortParts[1].ToLower() == "desc"))
                {
                    string propertyName = sortParts[0].ToLower();

                    var validProperties = typeof(Food).GetProperties().Select(p => p.Name.ToLower());

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
            return query.Include(x=>x.Pets).ToList();
        }
    }
}
