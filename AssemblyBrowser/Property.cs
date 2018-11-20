using System.Reflection;

namespace AssemblyBrowser
{
    public class Property : IElement
    {
        public Property(PropertyInfo property)
        {
            Name = GenericChecker.GetTypeName(property.PropertyType) + " " + property.Name;
        }

        public string Name { get; set; }
    }
}
