using ECommerce.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Context
{
    public class LoggingDbContext : DbContext
    {
        public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options) { }

        public DbSet<LogEntries> LogEntries { get; set; }
    }
}
