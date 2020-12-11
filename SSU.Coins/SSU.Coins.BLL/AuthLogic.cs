using SSU.Coins.BLL.Interface;
using SSU.Coins.DAL.Interface;
using System.Security.Cryptography;

namespace SSU.Coins.BLL
{
    public class AuthLogic : IAuthLogic
    {
        private IAuthDao _authDao;

        public AuthLogic(IAuthDao authDao)
        {
            _authDao = authDao;
        }

        public bool CanLogin(string login, byte[] password)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] hashValue = mySHA256.ComputeHash(password);
                password = hashValue;

                return _authDao.CanLogin(login, password);
            }
        }
    }
}
