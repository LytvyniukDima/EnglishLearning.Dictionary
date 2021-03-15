using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Application.Constants
{
    internal static class AbbreviationConstants
    {
        public static readonly IReadOnlyDictionary<string, string> WordsWithApostropheMap = new Dictionary<string, string>()
        {
            { "'s", "is" },
            { "'re", "are" },
            { "'m", "am" },
            { "n't", "not" },
            { "'ll", "will" },
            { "'ve", "have" },
        };
    }
}