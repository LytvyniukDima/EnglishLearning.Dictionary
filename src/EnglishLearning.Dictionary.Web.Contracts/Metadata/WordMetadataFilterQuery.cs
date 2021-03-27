using EnglishLearning.Dictionary.Common.Models;

namespace EnglishLearning.Dictionary.Web.Contracts.Metadata
{
    public class WordMetadataFilterQuery
    {
        public string Topic { get; set; }

        public DictionaryEnglishLevel Level { get; set; }
    }
}