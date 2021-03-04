using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XH.BaseProject.Infastructure.Database
{
    /// <summary>
    /// using migarate ef core in class library 
    /// run when migrations
    /// </summary>
    public class BaseContextFactory : IDesignTimeDbContextFactory<BaseContext>
    {
        BaseContext IDesignTimeDbContextFactory<BaseContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BaseContext>();

            var connectionString = configuration.GetConnectionString("BaseContext");

            builder.UseSqlServer(connectionString);

            return new BaseContext(builder.Options);
        }
    }
}
