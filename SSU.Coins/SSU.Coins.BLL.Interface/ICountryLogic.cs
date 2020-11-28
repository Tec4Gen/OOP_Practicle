using SSU.Coins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.Coins.BLL.Interface
{
    public interface ICountryLogic
    {
        Country GetById(int id);

        IEnumerable<Country> GetAll();

        void RemoveById(int id);

        void Update(Country coin);
    }
}
