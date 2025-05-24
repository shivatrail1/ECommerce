using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services.Interfaces
{
    public interface ILogService
    {
        Task LogInfo(string message);
        Task LogError(string message, Exception ex);

    }
}
