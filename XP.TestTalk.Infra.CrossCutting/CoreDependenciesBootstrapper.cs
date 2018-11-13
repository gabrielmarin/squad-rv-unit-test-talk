using SimpleInjector;
using XP.TestTalk.Application;
using XP.TestTalk.Domain.Application;
using XP.TestTalk.Domain.Infra;
using XP.TestTalk.Infra.Data;

namespace XP.TestTalk.Infra.CrossCutting
{
    public static class CoreDependenciesBootstrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IAccountRepository, AccountRepository>();
            container.Register<IAccountApplicationService, AccountApplicationService>();

            container.Register<IStocksRepository, StocksRepository>();
            container.Register<IStocksApplicationService, StocksApplicationService>();

            container.Register<IOrderApplicationService, OrderApplicationService>();
        }
    }
}