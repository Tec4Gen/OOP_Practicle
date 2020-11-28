using SSU.Coins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.Coins.DAL.Interface
{
    public interface IMaterialDao
    {
        Material GetById(int id);

        IEnumerable<Material> GetAll();

        void RemoveById(int id);

        void Update(Material coin);
    }
}
