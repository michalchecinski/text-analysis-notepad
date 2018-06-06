using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisNotepad
{
    public class SentimentJson
    {
        public SentimentDocument[] documents { get; set; }
        public object[] errors { get; set; }
    }

    public class SentimentDocument
    {
        public float score { get; set; }
        public string id { get; set; }
    }

}
