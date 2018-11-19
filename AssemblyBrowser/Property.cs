using System.Reflection;

namespace AssemblyBrowser
{
    public class Property
    {
        public Property(PropertyInfo property)
        {
            Name = GenericChecker.GetTypeName(property.PropertyType) + " " + property.Name;
        }

        public string Name { get; set; }
    }
}
