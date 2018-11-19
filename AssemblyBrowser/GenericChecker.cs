using System;

namespace AssemblyBrowser
{
    public static class GenericChecker
    {
        public static string GetTypeName(Type type)
        {
            if (type.IsGenericType)
                return type.Name + "<" + GetGenericArguments(type.GenericTypeArguments) + ">";
            else
                return type.Name;
        }

        private static string GetGenericArguments(Type[] argumentTypes)
        {
            string result = "";
            foreach (Type type in argumentTypes)
            {
                if (type.IsGenericType)
                    result += type.Name + "<" + GetGenericArguments(type.GenericTypeArguments) + ">";
                else
                    result += type.Name;
            }
            return result;
        }
    }
}
