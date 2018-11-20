using System.Reflection;

namespace AssemblyBrowser
{
    public class Method : IElement
    {
        public Method(MethodInfo method)
        {
            Name = GenericChecker.GetTypeName(method.ReturnParameter.ParameterType) + " " + method.Name;
            AddParamsToName(method);
        }

        public string Name { get; set; }

        private void AddParamsToName(MethodInfo methodInfo)
        {
            int cnt = 1;
            ParameterInfo[] parameters = methodInfo.GetParameters();
            Name += "(";
            foreach (ParameterInfo parameter in parameters)
            {
                Name += (GenericChecker.GetTypeName(parameter.ParameterType) + " " + parameter.Name);
                if (cnt != parameters.Length)
                    Name += ", ";
                cnt++;
            }
            Name += ")";
        }
    }
}
