using System;
using System.Collections.Generic;
using System.Reflection;

namespace AssemblyBrowser
{
    public class ClassInfo
    {
        public ClassInfo(Type _type)
        {
            type = _type;
            Name = type.Name;
            
            ElementsInit();
            ScanFields();
            ScanProperties();
            ScanMethods();
        }

        public string Name { get; set; }
        private Type type;
        public List<ClassInfoElements> Elements { get; set; }

        public void ElementsInit()
        {
            Elements = new List<ClassInfoElements>();
            Elements.Add(new ClassInfoElements("Fields"));
            Elements.Add(new ClassInfoElements("Properties"));
            Elements.Add(new ClassInfoElements("Methods"));
        }

        public void ScanFields()
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                Elements[0].ClassificationElements.Add(new Field(field));
            }
        }
        
        public void ScanProperties()
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Static | 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                Elements[1].ClassificationElements.Add(new Property(property));
            }
        }
        
        public void ScanMethods()
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                if (!method.IsSpecialName)
                    Elements[2].ClassificationElements.Add(new Method(method));
            }
        }
    }
}
