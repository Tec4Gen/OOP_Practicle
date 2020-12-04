using SSU.Coins.BLL.Interface;
using SSU.Coins.DAL.Interface;

namespace SSU.Coins.BLL
{
    public class MyRoleProviderLogic : IMyRoleProviderLogic
    {
        private IMyRoleProviderDao _provDao;

        public MyRoleProviderLogic(IMyRoleProviderDao provDao)
        {
            _provDao = provDao;
        }

        public string GetRolesForUser(string username)
        {
            return _provDao.GetRolesForUser(username);
        }
    }
}
