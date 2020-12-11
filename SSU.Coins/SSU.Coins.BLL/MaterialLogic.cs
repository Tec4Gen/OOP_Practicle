using SSU.Coins.BLL.Interface;
using SSU.Coins.DAL.Interface;
using SSU.Coins.Entities;
using System.Collections.Generic;

namespace SSU.Coins.BLL
{
    public class MaterialLogic : IMaterialLogic
    {
        private IMaterialDao _materialLogic;

        public MaterialLogic(IMaterialDao materialLogic)
        {
            _materialLogic = materialLogic;
        }

        public IEnumerable<Material> GetAll()
        {
            return _materialLogic.GetAll();
        }

        public Material GetById(int id)
        {
            return _materialLogic.GetById(id);
        }

        public void RemoveById(int id, ICollection<Error> errorList)
        {
            _materialLogic.RemoveById(id);
        }

        public void Update(Material coin, ICollection<Error> errorList)
        {
            _materialLogic.Update(coin);
        }
    }
}
