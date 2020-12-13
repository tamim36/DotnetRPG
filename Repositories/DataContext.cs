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
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
    }
}
