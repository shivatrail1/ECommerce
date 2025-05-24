using ECommerce.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Repository.Interfaces
{
    public interface ILogRepository
    {
        Task SaveLogAsync(LogEntries entry);
    }

}
