using SSU.Coins.DAL.Interface;
using SSU.Coins.Entities;
using System;
using System.Collections.Generic;

namespace SSU.Coins.DAL
{
    public class CoinDao : ICoinDao
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

        public void Update(Coin coin)
        {
            throw new NotImplementedException();
        }
    }
}
