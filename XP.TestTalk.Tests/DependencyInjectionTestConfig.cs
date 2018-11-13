using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XP.TestTalk.Infra.CrossCutting;

namespace XP.TestTalk.Tests
{
    public static class DependencyInjectionTestConfig
    {
        public static Container InitializeDependencyContainer()
        {
            var container = new Container();            
            CoreDependenciesBootstrapper.RegisterServices(container);            
            container.Verify();            
            return container;
        }
    }
}
