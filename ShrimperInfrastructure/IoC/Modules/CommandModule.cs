using Autofac;
using ShrimperInfrastructure.Commands;
using ShrimperInfrastructure.Commands.Users;
using ShrimperInfrastructure.Handlers.Users;
using ShrimperInfrastructure.Mappers;
using ShrimperInfrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace ShrimperInfrastructure.IoC.Modules
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LoginUserHandler>()
                .As<ICommandHandler<LoginUser>>()
                .InstancePerLifetimeScope();
        }
    }
}
