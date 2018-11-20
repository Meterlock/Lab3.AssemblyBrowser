using System.Collections.Generic;

namespace AssemblyBrowser
{
    public class ClassInfoElements
    {
        public ClassInfoElements(string classification)
        {
            Classification = classification;
            ClassificationElements = new List<IElement>();
        }

        public string Classification { get; set; }
        public List<IElement> ClassificationElements { get; set; }        
    }
}
