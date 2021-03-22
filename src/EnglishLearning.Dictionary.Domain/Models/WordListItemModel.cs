using System;
using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Domain.Models
{
    public class WordListItemModel
    {
        public string Id { get; set; }
        
        public Guid UserId { get; set; }
        
        public string Word { get; set; }
        
        public bool IsLearned { get; set; }
        
        public IReadOnlyList<WordDefinitionModel> WordDefinitions { get; set; }
    }
}