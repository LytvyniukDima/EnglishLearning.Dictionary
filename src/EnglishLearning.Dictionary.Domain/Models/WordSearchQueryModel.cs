using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Domain.Models
{
    public class WordSearchQueryModel
    {
        public IReadOnlyList<string> Words { get; set; }
    }
}