using System;
using System.Collections.Generic;
using EnglishLearning.Dictionary.Common.Models;

namespace EnglishLearning.Dictionary.Application.Constants
{
    public static class EnglishLevelConstants
    {
        public static IReadOnlyDictionary<string, DictionaryEnglishLevel> EnglishLevelMapInternal = new Dictionary<string, DictionaryEnglishLevel>(StringComparer.InvariantCultureIgnoreCase)
        {
            { "A1", DictionaryEnglishLevel.Elementary },
            { "A2", DictionaryEnglishLevel.Elementary },
            { "B1", DictionaryEnglishLevel.PreIntermediate },
            { "B2", DictionaryEnglishLevel.UpperIntermediate },
            { "C1", DictionaryEnglishLevel.Advanced },
            { "C2", DictionaryEnglishLevel.Advanced },
        };
    }
}