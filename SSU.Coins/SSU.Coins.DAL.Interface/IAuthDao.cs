namespace SSU.Coins.DAL.Interface
{
    public interface IAuthDao
    {
        bool CanLogin(string login, byte[] password);

        bool IsExistsLogin(string login);
    }
}
