using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string URLAmadeus { get; set; }
    }
}
