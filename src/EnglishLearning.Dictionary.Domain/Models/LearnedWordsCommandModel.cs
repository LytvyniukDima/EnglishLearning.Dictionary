using System;
using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Domain.Models
{
    public class LearnedWordsCommandModel
    {
        public Guid UserId { get; set; }
        
        public IReadOnlyList<string> Words { get; set; }
    }
}