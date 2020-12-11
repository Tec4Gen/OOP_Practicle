namespace SSU.Coins.BLL.Interface
{
    public interface IAuthLogic
    {
        bool CanLogin(string login, byte[] password);
    }
}
