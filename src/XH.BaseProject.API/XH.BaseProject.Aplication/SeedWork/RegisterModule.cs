using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XH.BaseProject.Aplication.Handle.User;
using XH.BaseProject.Domain.Users;

namespace XH.BaseProject.Aplication.SeedWork
{
   public class RegisterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType(typeof(UserRequesHandle))
                 .AsSelf()
                 .As(typeof(IUserRepository))
                 .InstancePerDependency();
        }
    }
}
