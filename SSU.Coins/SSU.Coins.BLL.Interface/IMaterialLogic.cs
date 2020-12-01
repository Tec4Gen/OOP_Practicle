using SSU.Coins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
