using SSU.Coins.Entities;
using System.Collections.Generic;

namespace SSU.Coins.DAL.Interface
{
    public interface IUserDao
    {
        User GetById(int id);

        User GetByLogin(string login);

        void Add(User user);

        void Remove(int id);

        void Update(User user);

        bool Auth(User user);

        IEnumerable<User> GetAll();

        IEnumerable<User> GetAllUserByRole(int id);
    }
}
