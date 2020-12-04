using SSU.Coins.Entities;
using System.Collections.Generic;

namespace SSU.Coins.DAL.Interface
{
    public interface IRoleWebSiteDao
    {
        IEnumerable<RoleWebSite> GetAll();

        RoleWebSite GetById(int id);
    }
}
