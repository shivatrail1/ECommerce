using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Models
{
    public class LogEntries
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public string Exception { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
