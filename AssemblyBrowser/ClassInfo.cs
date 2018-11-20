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

            Elements = new List<ClassInfoElements>();
            ScanFields();
            ScanProperties();
            ScanMethods();
        }

        public string Name { get; set; }
        private Type type;
        public List<ClassInfoElements> Elements { get; set; }

        public void ScanFields()
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                if (Elements.Find(x => x.Classification == "Fields") == null)
                    Elements.Add(new ClassInfoElements("Fields"));
                Elements.Find(x => x.Classification == "Fields").ClassificationElements.Add(new Field(field));
            }
        }
        
        public void ScanProperties()
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Static | 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                if (Elements.Find(x => x.Classification == "Properties") == null)
                    Elements.Add(new ClassInfoElements("Properties"));
                Elements.Find(x => x.Classification == "Properties").ClassificationElements.Add(new Property(property));
            }
        }
        
        public void ScanMethods()
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                if (Elements.Find(x => x.Classification == "Methods") == null)
                    Elements.Add(new ClassInfoElements("Methods"));
                if (!method.IsSpecialName)
                    Elements.Find(x => x.Classification == "Methods").ClassificationElements.Add(new Method(method));
            }
        }
    }
}
