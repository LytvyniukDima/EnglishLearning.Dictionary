using System;

namespace EnglishLearning.Dictionary.ExternalServices.Contracts
{
    public class FileInfoContract
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Extension { get; set; }
    }
}