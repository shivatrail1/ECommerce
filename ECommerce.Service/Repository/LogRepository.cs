using ECommerce.Service.Context;
using ECommerce.Service.Models;
using ECommerce.Service.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly LoggingDbContext _context;

        public LogRepository(LoggingDbContext context)
        {
            _context = context;
        }

        public async Task SaveLogAsync(LogEntries entry)
        {
            _context.LogEntries.Add(entry);
            await _context.SaveChangesAsync();
        }
    }

}
