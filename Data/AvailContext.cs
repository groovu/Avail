using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Availibility2.Models
{
    public class AvailContext : DbContext
    {
        public AvailContext (DbContextOptions<AvailContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Availibility2.Models.Avail> Avail { get; set; }
    }
}
