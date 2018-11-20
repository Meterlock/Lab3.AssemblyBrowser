using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
