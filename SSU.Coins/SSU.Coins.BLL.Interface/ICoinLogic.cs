using SSU.Coins.Entities;
using System.Collections.Generic;

namespace SSU.Coins.BLL.Interface
{
    public interface ICoinLogic
    {
        void Add(Coin coin, out ICollection<Error> errorList);
        Coin GetById(int id);

        IEnumerable<Coin> GetAll();

        void RemoveById(int id, ICollection<Error> errorList);

        void Update(Coin coin, ICollection<Error> errorList);

        IEnumerable<Coin> GetByTitle(string title);

        IEnumerable<Coin> GetByTitleAndCountry(string title, int idCountry);

        IEnumerable<Coin> GetByPrice(int price);

        IEnumerable<Coin> GetByMaterial(int id);

        IEnumerable<Coin> GetByCountry(int id);

        IEnumerable<Coin> GetByDate(int id);
    }
}
