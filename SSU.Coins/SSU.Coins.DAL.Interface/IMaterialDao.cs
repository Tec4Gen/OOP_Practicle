using SSU.Coins.Entities;
using System.Collections.Generic;

namespace SSU.Coins.DAL.Interface
{
    public interface IMaterialDao
    {
        Material GetById(int id);

        Material GetByTitle(string title);

        IEnumerable<Material> GetAll();

        void RemoveById(int id);

        void Update(Material coin);
    }
}
