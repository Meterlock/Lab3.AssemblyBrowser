using System;
using System.Collections.Generic;

namespace TestLib
{
    class Testable
    {
        public int number;
        public List<int> list;
        public int[] arr;
        string str = "";
        private static float floatfld;

        public void MyMethod(ref int num, float num2, out string str)
        {
            str = "hello";
        }

        public float FloatProperty
        {
            set
            {
                floatfld = value;
            }
            get
            {
                return floatfld;
            }
        }

        public int IntProperty { get; set; }
    }

    public abstract class Testable2
    {
        private int abc;
        public abstract int prop { get; }
        public abstract void Method();
    }

    public class Testable3
    {
        public virtual int MethodVirt()
        {
            return 0;
        }
    }
}

namespace NS2
{
    public class SomeClass
    {
        public SomeClass() { }
        private object nextMethod(int val)
        {
            return new Object();
        }
    }
}