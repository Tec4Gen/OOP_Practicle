using SSU.Coins.BLL.Interface;
using SSU.Coins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.Coins.BLL
{
    public class CoinLogic : ICoinLogic
    {
        public IEnumerable<Coin> GetAll()
        {
            throw new NotImplementedException();
        }

        public Coin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Entities.Coin coin)
        {
            throw new NotImplementedException();
        }
    }
}
