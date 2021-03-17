using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Web.Contracts
{
    public class WordSearch
    {
        public WordDetails Word { get; set; }
        
        public IReadOnlyList<string> SimilarWords { get; set; }
    }
}