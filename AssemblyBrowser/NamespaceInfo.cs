using System.Collections.Generic;

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
