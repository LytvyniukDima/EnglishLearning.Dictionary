using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Domain.Models.Metadata
{
    public class WordMetadataQueryModel
    {
        public IReadOnlyList<string> Words { get; set; }
    }
}