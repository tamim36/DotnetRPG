using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class DataContext : DbContext
    {
        public DbSet<Character> characters { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Weapon> weapons { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
    }
}

/*From Solution Directory ->
dotnet ef migrations add InitialMigration --startup-project "WebService" --project "Repositories"
From WebService Directory ->
dotnet ef database update*/