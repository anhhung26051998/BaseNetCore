using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XH.BaseProject.Domain.Users;
using XH.BaseProject.Infastructure.Domain.Users;
using XH.BaseProject.Infastructure.Interfaces;
using XH.BaseProject.Infastructure.Repository;

namespace XH.BaseProject.Infastructure.Database
{
    public class DataAccessModule : Module
    {
        private readonly string _databaseConnectionString;
        public DataAccessModule(string databaseConnectionString)
        {
            this._databaseConnectionString = databaseConnectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
              .As<IUnitOfWork>()
              .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(RepositoryBase<>))
                .AsSelf()
                .As(typeof(IRepositoryBase<>))
                .InstancePerDependency();

            builder.RegisterType<SqlConnectionFactory>()
            .As<ISqlConnectionFactory>()
            .WithParameter("connectionString", _databaseConnectionString)
            .InstancePerLifetimeScope();

            builder.RegisterType(typeof(UserRepository))
                 .AsSelf()
                 .As(typeof(IUserRepository))
                 .InstancePerDependency();
        }
    }
}
