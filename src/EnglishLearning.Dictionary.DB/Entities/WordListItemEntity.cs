using System;
using System.Collections.Generic;
using EnglishLearning.Utilities.Persistence.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Dictionary.DB.Entities
{
    public class WordListItemEntity : IEntity<string>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
        
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid UserId { get; set; }
        
        public string Word { get; set; }
        
        public List<WordDefinitionEntity> WordDefinitions { get; set; }
    }
}