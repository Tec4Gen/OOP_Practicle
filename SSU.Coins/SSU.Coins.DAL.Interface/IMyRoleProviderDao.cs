namespace SSU.Coins.DAL.Interface
{
    public interface IMyRoleProviderDao
    {
        string GetRolesForUser(string username);
    }
}
