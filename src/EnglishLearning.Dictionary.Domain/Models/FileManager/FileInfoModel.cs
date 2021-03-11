using System;
using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Domain.Models.FileManager
{
    public class FileInfoModel
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Extension { get; set; }
    }
}