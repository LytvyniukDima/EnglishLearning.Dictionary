using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Domain.Models;

namespace EnglishLearning.Dictionary.Application.Abstract
{
    public interface IWordListItemQueryService
    {
        Task<IReadOnlyList<WordListItemModel>> FindAllAsync(Guid userId);
    }
}