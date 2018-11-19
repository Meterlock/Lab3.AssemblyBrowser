using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    public class AssemblyInfo
    {
        public AssemblyInfo()
        {
            Namespaces = new List<NamespaceInfo>();
        }

        public List<NamespaceInfo> Namespaces { get; set; }
    }
}
