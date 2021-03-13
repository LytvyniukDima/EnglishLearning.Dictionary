using EnglishLearning.Dictionary.Common.Models;
using EnglishLearning.Utilities.Persistence.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Dictionary.DB.Entities
{
    public class WordMetadataMongoEntity : IEntity<string>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Word { get; set; }
        
        public string GuideWord { get; set; }
        
        [BsonRepresentation(BsonType.String)]
        public DictionaryEnglishLevel Level { get; set; }
        
        public string POS { get; set; }
        
        public string Topic { get; set; }
    }
}