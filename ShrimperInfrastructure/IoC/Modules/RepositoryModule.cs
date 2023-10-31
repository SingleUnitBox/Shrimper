using Autofac;
using ShrimperCore.Repositories;
using ShrimperInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimperInfrastructure.IoC.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryUserRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<InMemoryTokenRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
