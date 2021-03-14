using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Web.Contracts.Metadata
{
    public class WordMetadataQuery
    {
        public IReadOnlyList<string> Words { get; set; }
    }
}