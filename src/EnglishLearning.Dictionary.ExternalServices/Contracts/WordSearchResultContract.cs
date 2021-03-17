using System.Collections.Generic;

namespace EnglishLearning.Dictionary.ExternalServices.Contracts
{
    public class WordSearchResultContract
    {
        public int Total { get; set; }
        
        public IReadOnlyList<string> Data { get; set; }
    }
}