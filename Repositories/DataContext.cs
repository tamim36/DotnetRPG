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
        public DbSet<Skills> skills { get; set; }
        public DbSet<CharacterSkills> characterSkills { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSkills>()
                .HasKey(cs => new {cs.CharacterId, cs.SkillsId});

            modelBuilder.Entity<User>()
                .Property(users => users.Role).HasDefaultValue("Player");
        }
    }
}

/*From Solution Directory ->
dotnet ef migrations add InitialMigration --startup-project "WebService" --project "Repositories"
dotnet ef database update --startup-project "WebService" --project "Repositories"  */