﻿using SSU.Coins.Entities;
using System.Collections.Generic;

namespace SSU.Coins.DAL.Interface
{
    public interface ICountryDao
    {
        Country GetById(int id);

        Country GetByTitle(string title);

        IEnumerable<Country> GetAll();

        void RemoveById(int id);

        void Update(Country coin);
    }
}
