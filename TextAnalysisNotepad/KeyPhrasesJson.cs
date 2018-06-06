using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisNotepad
{

    public class KeyPhrasesJson
    {
        public Phrases[] documents { get; set; }
    }

    public class Phrases
    {
        public string[] keyPhrases { get; set; }
        public string id { get; set; }
    }
}
