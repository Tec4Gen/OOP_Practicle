using SSU.Coins.BLL.Interface;
using SSU.Coins.DAL.Interface;
using SSU.Coins.Entities;
using System;
using System.Collections.Generic;

namespace SSU.Coins.BLL
{
    public class CoinLogic : ICoinLogic
    {
        private ICoinDao _coinLogic;

        public CoinLogic(ICoinDao coinLogic)
        {
            _coinLogic = coinLogic;
        }

        public void Add(Coin coin, out ICollection<Error> errorList)
        {
            errorList = new List<Error>();
            try
            {
                _coinLogic.Add(coin);
            }
            catch (Exception ex)
            {
                errorList.Add(new Error { Message = ex.Message });
            }
        }

        public IEnumerable<Coin> GetAll()
        {
            return _coinLogic.GetAll();
        }

        public IEnumerable<Coin> GetByCountry(int id)
        {
            return _coinLogic.GetByCountry(id);
        }

        public IEnumerable<Coin> GetByDate(int id)
        {
            return _coinLogic.GetByDate(id);
        }

        public IEnumerable<Coin> GetByUser(int userId)
        {
            return _coinLogic.GetByUser(userId);
        }

        public IEnumerable<Coin> GetBySelling(bool isSelling)
        {
            return _coinLogic.GetBySelling(isSelling);
        }

        public Coin GetById(int id)
        {
            return _coinLogic.GetById(id);
        }

        public IEnumerable<Coin> GetByMaterial(int id)
        {
            return _coinLogic.GetByMaterial(id);
        }

        public IEnumerable<Coin> GetByPrice(int price)
        {
            return _coinLogic.GetByPrice(price);
        }

        public IEnumerable<Coin> GetByTitle(string title)
        {
            return _coinLogic.GetByTitle(title);
        }

        public IEnumerable<Coin> GetByTitleAndCountry(string title, int idCountry)
        {
            return _coinLogic.GetByTitleAndCountry(title, idCountry);
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
