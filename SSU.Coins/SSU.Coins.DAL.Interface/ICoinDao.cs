using SSU.Coins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.Coins.DAL.Interface
{
    public interface ICoinDao
    {
        Coin GetById(int id);

        IEnumerable<Coin> GetAll();

        void RemoveById(int id);

        void Update(Coin coin);
    }
}
