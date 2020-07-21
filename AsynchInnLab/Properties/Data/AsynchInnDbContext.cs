using AsynchInnLab.Properties.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Properties.Data
{
    public class AsynchInDbContext : DbContext
    {
        public AsynchInDbContext(DbContextOptions<AsynchInDbContext> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
