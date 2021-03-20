using System;

namespace EnglishLearning.Dictionary.Domain.Models
{
    public class AddWordListDefinitionCommandModel
    {
        public Guid UserId { get; set; }
        
        public string Word { get; set; }
        
        public WordDefinitionModel WordDefinition { get; set; }
    }
}