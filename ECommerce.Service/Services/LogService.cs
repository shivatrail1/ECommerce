using ECommerce.Service.Models;
using ECommerce.Service.Repository.Interfaces;
using ECommerce.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task LogInfo(string message)
        {
            await _logRepository.SaveLogAsync(new LogEntries
            {
                Message = message,
                Level = "INFO",
                Timestamp = DateTime.UtcNow
            });
        }

        public async Task LogError(string message, Exception ex)
        {
            await _logRepository.SaveLogAsync(new LogEntries
            {
                Message = $"{message}: {ex.Message}",
                Level = "ERROR",
                Timestamp = DateTime.UtcNow
            });
        }
    }

}
