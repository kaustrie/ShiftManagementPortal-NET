using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

//using Microsoft.Extensions.Configuration;

namespace ShiftManagementPortal.Infrastructure.Data
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<Database>
    {
        public DatabaseContextFactory()
        { }
        
        public Database CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<Database>();
            
            var connectionString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];

            builder.UseSqlServer(connectionString); 
            
            return new Database(builder.Options);
        }
    }
}


