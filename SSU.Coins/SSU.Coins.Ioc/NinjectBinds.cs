using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using SSU.Coins.BLL;
using SSU.Coins.BLL.Interface;
using SSU.Coins.DAL;
using SSU.Coins.DAL.Interface;

namespace SSU.Coins.Ioc
{
    public class NinjectBinds : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthDao>().To<AuthDao>();
            Bind<ICoinDao>().To<CoinDao>();
            Bind<ICountryDao>().To<CountryDao>();
            Bind<IMaterialDao>().To<MaterialDao>();
            Bind<IMyRoleProviderDao>().To<MyRoleProviderDao>();
            Bind<IRoleWebSiteDao>().To<RoleWebSiteDao>();
            Bind<IUserDao>().To<UserDao>();

            Bind<IAuthLogic>().To<AuthLogic>();
            Bind<ICoinLogic>().To<CoinLogic>();
            Bind<ICountryLogic>().To<CountryLogic>();
            Bind<IMaterialLogic>().To<MaterialLogic>();
            Bind<IMyRoleProviderLogic>().To<MyRoleProviderLogic>();
            Bind<IRoleWebSiteLogic>().To<RoleWebSiteLogic>();
            Bind<IUserLogic>().To<UserLogic>();
        }
    }
}
