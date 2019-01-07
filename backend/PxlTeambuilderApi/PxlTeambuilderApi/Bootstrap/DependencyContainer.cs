using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PxlTeambuilderApi.Data;
using PxlTeambuilderApi.Repositories.Implementations;
using PxlTeambuilderApi.Repositories.Interfaces;
using PxlTeambuilderApi.Services.Implementations;
using PxlTeambuilderApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Bootstrap
{
    public class DependencyContainer
    {

        public static ContainerBuilder RegisterDependencies(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            //repositories
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProjectRepository>().As<IProjectRepository>().InstancePerLifetimeScope();

            //services
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerLifetimeScope();
            builder.RegisterType<PasswordService>().As<IPasswordService>().InstancePerLifetimeScope();

            //othes
            builder.RegisterType<PxlTeamBuilderContext>().InstancePerLifetimeScope();

            builder.Populate(services);
            return builder;
        }

    }
}
