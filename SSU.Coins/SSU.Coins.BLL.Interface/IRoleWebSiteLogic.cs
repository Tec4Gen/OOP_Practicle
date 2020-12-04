using SSU.Coins.Entities;
using System.Collections.Generic;

namespace SSU.Coins.BLL.Interface
{
    public interface IRoleWebSiteLogic
    {
        IEnumerable<RoleWebSite> GetAll();

        RoleWebSite GetById(int id);
    }
}
