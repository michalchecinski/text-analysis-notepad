using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisNotepad
{
    public class SendJson
    {
        public Document[] documents { get; set; }
    }

    public class Document
    {
        public string id { get; set; }
        public string text { get; set; }
    }
}
