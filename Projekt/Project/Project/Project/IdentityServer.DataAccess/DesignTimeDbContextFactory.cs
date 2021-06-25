using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace IdentityServer.DataAccess
{
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReportsDb>
        {
            public ReportsDb CreateDbContext([NotNull] string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<ReportsDb>();

                var connectionString = configuration.GetConnectionString(name: "ReportsDb");

                builder.UseSqlServer(connectionString);

                return new ReportsDb(builder.Options);
            }
        
    }
}
