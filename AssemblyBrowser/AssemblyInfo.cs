using System.Collections.Generic;

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
