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
            /*
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Fireball", Damage = 30 },
                new Skill { Id = 2, Name = "Frenzy", Damage = 20 },
                new Skill { Id = 3, Name = "Blizzard", Damage = 50 }
            );

            Utility.CreatePasswordHash("123456", out byte[] passwordHash, out byte[] passwordSalt);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "User1" },
                new User { Id = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "User2" }
            );

            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    Name = "Frodo",
                    Class = RpgClass.Knight,
                    HitPoints = 100,
                    Strength = 15,
                    Defense = 10,
                    Intelligence = 10,
                    UserId = 1
                },
                new Character
                {
                    Id = 2,
                    Name = "Raistlin",
                    Class = RpgClass.Mage,
                    HitPoints = 100,
                    Strength = 5,
                    Defense = 5,
                    Intelligence = 20,
                    UserId = 2
                }
            );

            modelBuilder.Entity<Weapon>().HasData(
                new Weapon { Id = 1, Name = "The Master Sword", Damage = 20, CharacterId = 1 },
                new Weapon { Id = 2, Name = "Crystal Wand", Damage = 5, CharacterId = 2 }
            );

            modelBuilder.Entity<CharacterSkill>().HasData(
                new CharacterSkill { CharacterId = 1, SkillId = 2 },
                new CharacterSkill { CharacterId = 2, SkillId = 1 },
                new CharacterSkill { CharacterId = 2, SkillId = 3 }
            );*/
        }
    }
}

/*From Solution Directory ->
dotnet ef migrations add InitialMigration --startup-project "WebService" --project "Repositories"
dotnet ef database update --startup-project "WebService" --project "Repositories"  */