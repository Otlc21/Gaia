using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton
{
    public class Ticket_ProcessEDoc
    {
        public string _xml = $@"";
        public string _service = "TATREQ_23_1_1A";

        public string GetXML()
        {
            return _xml;
        }
        
        public string GetService()
        {
            return _service;
        }
    }
}
