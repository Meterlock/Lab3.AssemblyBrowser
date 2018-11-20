using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Initialize()
        {
            string filename = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\TestLib\\obj\\Debug\\TestLib.dll";
            AssemblyBrowser.AssemblyBrowser browser = new AssemblyBrowser.AssemblyBrowser();

            result = browser.Browse(filename);
        }

        AssemblyBrowser.AssemblyInfo result;

        [TestMethod]
        public void NamespacesTest()
        {
            Assert.IsNotNull(result.Namespaces);
            Assert.AreEqual(2, result.Namespaces.Count);
            Assert.AreEqual(result.Namespaces[0].Name, nameof(NS2));
            Assert.AreEqual(result.Namespaces[1].Name, nameof(TestLib));
        }

        [TestMethod]
        public void ClassesTest()
        {
            Assert.IsNotNull(result.Namespaces[0].Classes);
            Assert.IsNotNull(result.Namespaces[1].Classes);
            Assert.AreEqual(1, result.Namespaces[0].Classes.Count);
            Assert.AreEqual(3, result.Namespaces[1].Classes.Count);
            Assert.IsNotNull(result.Namespaces[0].Classes.Find(x => x.Name == nameof(NS2.SomeClass)));
        }

        [TestMethod]
        public void FieldsTest()
        {
            Assert.IsNotNull(result.Namespaces[1].Classes[1].Elements[0].ClassificationElements);
            Assert.AreEqual(1, result.Namespaces[1].Classes[1].Elements[0].ClassificationElements.Count);
        }

        [TestMethod]
        public void PropertiesTest()
        {
            Assert.IsNotNull(result.Namespaces[1].Classes[0].Elements[1].ClassificationElements);
            Assert.AreEqual(2, result.Namespaces[1].Classes[0].Elements[1].ClassificationElements.Count);
        }

        [TestMethod]
        public void MethodsTest()
        {
            Assert.IsNotNull(result.Namespaces[1].Classes[2].Elements[2].ClassificationElements);
            Assert.AreEqual(1, result.Namespaces[1].Classes[2].Elements[2].ClassificationElements.Count);
        }
    }
}
