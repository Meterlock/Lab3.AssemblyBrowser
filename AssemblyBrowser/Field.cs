using System.Reflection;

namespace AssemblyBrowser
{
    public class Field
    {
        public Field(FieldInfo field)
        {
            Name = GenericChecker.GetTypeName(field.FieldType) + " " + field.Name;
        }

        public string Name { get; set; }
    }
}
