using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    public class ClassInfo
    {
        public ClassInfo(Type _type)
        {
            type = _type;
            Name = type.Name;
        }

        public string Name { get; set; }
        private Type type;
        public List<Field> Fields { get; set; }
        public List<Method> Methods { get; set; }
        public List<Property> Properties { get; set; }

        public void ScanFields()
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                Fields.Add(new Field(field));
            }
        }
        
        public void ScanProperties()
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Static | 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                Properties.Add(new Property(property));
            }
        }
        
        public void ScanMethods()
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                Methods.Add(new Method(method));
            }
        }
    }
}
