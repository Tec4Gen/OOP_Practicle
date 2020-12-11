using Ninject;
using SSU.Coins.BLL;
using SSU.Coins.BLL.Interface;
using SSU.Coins.Ioc;
using System;
using System.Web.Security;

namespace WebPL.Model
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        private IRoleWebSiteLogic _RoleWebSite = DependenciesResolver.Kernel.Get<RoleWebSiteLogic>();

        private IMyRoleProviderLogic _myRole = DependenciesResolver.Kernel.Get<MyRoleProviderLogic>();
        private IUserLogic _user = DependenciesResolver.Kernel.Get<UserLogic>();

        public override string[] GetRolesForUser(string username)
        {
            var role = _myRole.GetRolesForUser(username);

            if (role == "Admin")
                return new string[] { "Admin", "User" };
            else if (role == "User")
                return new string[] { "User" };
            else
                return new string[] { };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var user = _user.GetByLogin(username);

            var roleUser = _RoleWebSite.GetById(user.RoleWebSite);

            if (roleName == roleUser.Name)
                return true;
            return false;
        }

        #region NOT IMPLEMENTED
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}