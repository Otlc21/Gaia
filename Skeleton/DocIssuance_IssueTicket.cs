using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton
{
    public class DocIssuance_IssueTicket
    {
        public string _xml = $@"";
        public string _service = "TTKTIQ_15_1_1A";

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
