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
            int cnt = 1;
            string result = "";
            foreach (Type type in argumentTypes)
            {
                if (type.IsGenericType)
                    result += type.Name + "<" + GetGenericArguments(type.GenericTypeArguments) + ">";
                else
                    result += type.Name;
                if (cnt != argumentTypes.Length)
                    result += ",";
                cnt++;
            }
            return result;
        }
    }
}
