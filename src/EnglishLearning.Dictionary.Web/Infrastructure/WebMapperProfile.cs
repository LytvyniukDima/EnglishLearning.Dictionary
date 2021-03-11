using AutoMapper;
using EnglishLearning.Dictionary.Domain.Models.Metadata;
using EnglishLearning.Dictionary.Web.Contracts.Metadata;

namespace EnglishLearning.Dictionary.Web.Infrastructure
{
    public class WebMapperProfile : Profile
    {
        public WebMapperProfile()
        {
            CreateMap<CreateWordMetadataCommand, CreateWordMetadataCommandModel>();
        }
    }
}