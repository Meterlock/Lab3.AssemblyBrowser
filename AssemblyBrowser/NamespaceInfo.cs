using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    public class NamespaceInfo
    {
        public NamespaceInfo(string name)
        {
            Name = name;
            Classes = new List<ClassInfo>();
        }

        public string Name { get; set; }
        public List<ClassInfo> Classes { get; set; }
    }
}
