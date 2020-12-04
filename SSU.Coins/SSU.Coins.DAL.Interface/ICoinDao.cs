using SSU.Coins.Entities;
using System.Collections.Generic;

namespace SSU.Coins.DAL.Interface
{
    public interface ICoinDao
    {
        Coin GetById(int id);

        IEnumerable<Coin> GetAll();

        void RemoveById(int id);

        void Update(Coin coin);

        IEnumerable<Coin> GetByTitle(string title);

        IEnumerable<Coin> GetByPrice(int price);

        IEnumerable<Coin> GetByMaterial(int id);

        IEnumerable<Coin> GetByCountry(int id);
    }
}
