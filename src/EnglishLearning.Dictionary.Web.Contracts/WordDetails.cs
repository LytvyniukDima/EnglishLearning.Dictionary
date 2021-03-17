using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Web.Contracts
{
    public class WordDetails
    {
        public string Word { get; set; }
        
        public IReadOnlyList<WordDefinition> Results { get; set; }
    }
}