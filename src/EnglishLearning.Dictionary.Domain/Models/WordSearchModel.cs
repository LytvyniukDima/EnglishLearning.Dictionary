using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Domain.Models
{
    public class WordSearchModel
    {
        public WordDetailsModel Word { get; set; }
        
        public IReadOnlyList<string> SimilarWords { get; set; }
    }
}