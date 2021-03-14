using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Web.Contracts.Metadata
{
    public class AnalyseWordCommand
    {
        public IReadOnlyList<string> Words { get; set; }
    }
}