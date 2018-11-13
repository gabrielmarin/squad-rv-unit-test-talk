using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using XP.TestTalk.Infra.CrossCutting;

namespace XP.TestTalk.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static Container InitializeDependencyContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            CoreDependenciesBootstrapper.RegisterServices(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            return container;
        }
    }
}