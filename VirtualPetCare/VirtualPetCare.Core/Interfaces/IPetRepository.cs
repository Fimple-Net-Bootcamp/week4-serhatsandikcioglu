using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Core.Interfaces
{
    public interface IPetRepository
    {
        public List<Pet> GetAll( string? sort , int page, int size);
        Pet GetById(int id, bool relational);
        void Add(Pet pet);
        void Update(Pet pet);
        bool IsExist(int id);

    }
}
