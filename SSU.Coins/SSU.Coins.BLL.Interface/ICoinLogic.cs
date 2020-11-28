using SSU.Coins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.Coins.BLL.Interface
{
    public interface ICoinLogic
    {
        Coin GetById(int id);

        IEnumerable<Coin> GetAll();

        void RemoveById(int id);

        void Update(Coin coin);
    }
}
