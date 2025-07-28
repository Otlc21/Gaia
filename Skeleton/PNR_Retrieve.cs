using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton
{
    public class PNR_Retrieve
    {
        public string _xml = $@"";
        public string _service = "PNRRET_21_1_1A";

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
