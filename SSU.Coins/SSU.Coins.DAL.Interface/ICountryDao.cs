using SSU.Coins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.Coins.DAL.Interface
{
    public interface ICountryDao
    {
        Country GetById(int id);

        IEnumerable<Country> GetAll();

        void RemoveById(int id);

        void Update(Country coin);
    }
}
