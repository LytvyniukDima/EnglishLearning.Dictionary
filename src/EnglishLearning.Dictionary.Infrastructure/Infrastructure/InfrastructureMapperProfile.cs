using AutoMapper;
using EnglishLearning.Dictionary.Domain.Models.FileManager;
using EnglishLearning.Dictionary.ExternalServices.Contracts;

namespace EnglishLearning.Dictionary.Infrastructure.Infrastructure
{
    public class InfrastructureMapperProfile : Profile
    {
        public InfrastructureMapperProfile()
        {
            CreateMap<FileInfoContract, FileInfoModel>();
        }
    }
}