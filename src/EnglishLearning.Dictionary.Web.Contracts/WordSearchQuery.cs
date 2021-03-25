using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Web.Contracts
{
    public class WordSearchQuery
    {
        public IReadOnlyList<string> Words { get; set; }
    }
}