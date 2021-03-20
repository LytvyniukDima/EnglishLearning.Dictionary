using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Web.Contracts
{
    public class WordListItem
    {
        public string Id { get; set; }

        public string Word { get; set; }
        
        public IReadOnlyList<WordDefinition> WordDefinitions { get; set; }
    }
}