using DAL;
using DAL.Repositories;
using DAS.Domain;
using DAS.Domain.Users;
using Ninject.Modules;

namespace WebApplication4.App_Code
{
    internal class DefaultBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmail>().To<Email>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<ISystemRepository>().To<SystemRepository>();
            Bind<IUnitOfWork>().To<ASEntities>();
        }
    }
}
