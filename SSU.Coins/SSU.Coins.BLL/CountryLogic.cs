using SSU.Coins.BLL.Interface;
using SSU.Coins.DAL.Interface;
using SSU.Coins.Entities;
using System.Collections.Generic;

namespace SSU.Coins.BLL
{
    public class CountryLogic : ICountryLogic
    {
        private ICountryDao _countryLogic;

        public CountryLogic(ICountryDao countryLogic)
        {
            _countryLogic = countryLogic;
        }

        public IEnumerable<Country> GetAll()
        {
            return _countryLogic.GetAll();
        }

        public Country GetById(int id)
        {
            return _countryLogic.GetById(id);
        }

        public Country GetByTitle(string title)
        {
            return _countryLogic.GetByTitle(title);
        }

        public void RemoveById(int id, ICollection<Error> errorList)
        {
            _countryLogic.RemoveById(id);
        }

        public void Update(Country coin, ICollection<Error> errorList)
        {
            _countryLogic.Update(coin);
        }
    }
}
