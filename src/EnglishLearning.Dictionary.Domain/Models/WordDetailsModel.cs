using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Domain.Models
{
    public class WordDetailsModel
    {
        public string Word { get; set; }
        
        public IReadOnlyList<WordDefinitionModel> Results { get; set; }
    }
}