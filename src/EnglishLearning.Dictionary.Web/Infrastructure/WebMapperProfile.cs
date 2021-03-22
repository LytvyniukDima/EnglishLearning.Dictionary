using AutoMapper;
using EnglishLearning.Dictionary.Domain.Models;
using EnglishLearning.Dictionary.Domain.Models.Metadata;
using EnglishLearning.Dictionary.Web.Contracts;
using EnglishLearning.Dictionary.Web.Contracts.Metadata;

namespace EnglishLearning.Dictionary.Web.Infrastructure
{
    public class WebMapperProfile : Profile
    {
        public WebMapperProfile()
        {
            CreateMap<CreateWordMetadataCommand, CreateWordMetadataCommandModel>();

            CreateMap<WordMetadataModel, WordMetadata>();
            CreateMap<WordMetadataQuery, WordMetadataQueryModel>();

            CreateMap<WordDetailsModel, WordDetails>();
            CreateMap<WordDefinitionModel, WordDefinition>();
            CreateMap<WordDefinition, WordDefinitionModel>();
            CreateMap<WordSearchModel, WordSearch>();

            CreateMap<AddWordListDefinitionCommand, AddWordListDefinitionCommandModel>()
                .ForMember(dst => dst.UserId, opt => opt.Ignore());
            
            CreateMap<WordListItemModel, WordListItem>();

            CreateMap<LearnedWordsCommand, LearnedWordsCommandModel>()
                .ForMember(dst => dst.UserId, opt => opt.Ignore());
        }
    }
}