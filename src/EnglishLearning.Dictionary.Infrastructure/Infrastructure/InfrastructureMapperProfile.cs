using AutoMapper;
using EnglishLearning.Dictionary.DB.Entities;
using EnglishLearning.Dictionary.Domain.Models.FileManager;
using EnglishLearning.Dictionary.Domain.Models.Metadata;
using EnglishLearning.Dictionary.ExternalServices.Contracts;

namespace EnglishLearning.Dictionary.Infrastructure.Infrastructure
{
    public class InfrastructureMapperProfile : Profile
    {
        public InfrastructureMapperProfile()
        {
            CreateMap<FileInfoContract, FileInfoModel>();
            
            CreateMap<WordMetadataModel, WordMetadataMongoEntity>();
            CreateMap<WordMetadataMongoEntity, WordMetadataModel>();
        }
    }
}