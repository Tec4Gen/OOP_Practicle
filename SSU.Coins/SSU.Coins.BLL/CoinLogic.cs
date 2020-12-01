using SSU.Coins.BLL.Interface;
using SSU.Coins.DAL.Interface;
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
        private ICoinDao _coinLogic;

        public CoinLogic(ICoinDao coinLogic)
        {
            _coinLogic = coinLogic;
        }

        public IEnumerable<Coin> GetAll()
        {
            return _coinLogic.GetAll();
        }

        public Coin GetById(int id)
        {
            return _coinLogic.GetById(id);
        }

        public void RemoveById(int id, ICollection<Error> errorList)
        {
            _coinLogic.RemoveById(id);
        }

        public void Update(Coin coin, ICollection<Error> errorList)
        {
            _coinLogic.Update(coin);
        }
    }
}
