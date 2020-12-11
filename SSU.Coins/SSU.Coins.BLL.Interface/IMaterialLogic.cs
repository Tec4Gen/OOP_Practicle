using SSU.Coins.Entities;
using System.Collections.Generic;

namespace SSU.Coins.BLL.Interface
{
    public interface IMaterialLogic
    {
        Material GetById(int id);

        IEnumerable<Material> GetAll();

        void RemoveById(int id, ICollection<Error> errorList);

        void Update(Material coin, ICollection<Error> errorList);
    }
}
