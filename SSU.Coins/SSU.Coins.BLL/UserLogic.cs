using Epam.FitnessCenter.CustomException;
using SSU.Coins.BLL.Interface;
using SSU.Coins.DAL.Interface;
using SSU.Coins.Entities;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SSU.Coins.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDao _userDao;

        public UserLogic(IUserDao userLogic)
        {
            _userDao = userLogic;
        }

        public void Add(User user, out ICollection<Error> listError)
        {
            listError = new List<Error>();

            try
            {
                using (SHA256 mySHA256 = SHA256.Create())
                {
                    byte[] hashValue = mySHA256.ComputeHash(user.HashPassword);
                    user.HashPassword = hashValue;
                }
                _userDao.Add(user);
            }
            catch (UniqueIdentifierException ex)
            {
                listError.Add(new Error
                {
                    Message = ex.Message
                });
            }
            catch (RoleUndefinedException)
            {
                listError.Add(new Error
                {
                    Message = "Registration failed, please try again"
                });
            }
            catch
            {
                listError.Add(new Error
                {
                    Message = "Something went wrong"
                });
            }

        }

        public bool Auth(User user)
        {
            return _userDao.Auth(user); ;
        }

        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }

        public IEnumerable<User> GetAllUserByRole(int id)
        {
            return _userDao.GetAllUserByRole(id);
        }

        public User GetById(int id)
        {
            return _userDao.GetById(id);
        }

        public User GetByLogin(string login)
        {
            return _userDao.GetByLogin(login);
        }

        public void Remove(int id, out ICollection<Error> listError)
        {
            listError = new List<Error>();
            try
            {
                if (_userDao.GetById(id) == null)
                {
                    listError.Add(new Error
                    {
                        Message = "User won't find"
                    });
                    return;
                }

                _userDao.Remove(id);
            }
            //TODO Logger
            catch
            {
                listError.Add(new Error
                {
                    Message = "Internal error, try again"
                });
            }
        }

        public void Update(User user, out ICollection<Error> listError)
        {
            listError = new List<Error>();
            try
            {
                if (_userDao.GetById(user.Id) == null)
                {
                    listError.Add(new Error
                    {
                        Message = "User won't find"
                    });
                    return;
                }

                _userDao.Update(user);
            }
            //TODO Logger
            catch (RoleUndefinedException ex)
            {
                listError.Add(new Error
                {
                    Message = ex.Message
                });
            }
        }
    }
}
