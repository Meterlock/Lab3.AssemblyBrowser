using System;
using System.Reflection;

namespace AssemblyBrowser
{
    public class AssemblyBrowser
    {
        public AssemblyInfo Browse(string filename)
        {
            Assembly assembly;
            AssemblyInfo result = new AssemblyInfo();
            Type[] types;
            NamespaceInfo searchableNamesapce;

            assembly = Assembly.LoadFrom(filename);
            types = assembly.GetTypes();
            foreach (var type in types)
            {
                searchableNamesapce = result.Namespaces.Find(i => i.Name == type.Namespace);
                if (searchableNamesapce == null)
                {
                    searchableNamesapce = new NamespaceInfo(type.Namespace);
                    result.Namespaces.Add(searchableNamesapce);
                }
                searchableNamesapce.Classes.Add(new ClassInfo(type));
            }

            return result;
        }
    }
}
