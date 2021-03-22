using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Web.Contracts
{
    public class LearnedWordsCommand
    {
        public IReadOnlyList<string> Words { get; set; }
    }
}