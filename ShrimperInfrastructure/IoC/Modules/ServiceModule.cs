using Autofac;
using ShrimperInfrastructure.Commands;
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
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TokenService>()
                .As<ITokenService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<JwtProvider>()
                .As<IJwtProvider>()
                .InstancePerLifetimeScope();
        }
    }
}
