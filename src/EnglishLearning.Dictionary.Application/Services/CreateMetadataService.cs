using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Application.Constants;
using EnglishLearning.Dictionary.Domain.Models.Metadata;
using EnglishLearning.Dictionary.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;
using static EnglishLearning.Dictionary.Application.Constants.EnglishLevelConstants;

namespace EnglishLearning.Dictionary.Application.Services
{
    internal class CreateMetadataService : ICreateMetadataService
    {
        private readonly IFileRepository _fileRepository;

        private readonly IWordMetadataRepository _wordMetadataRepository;
        
        private readonly ILogger<CreateMetadataService> _logger;
        
        public CreateMetadataService(
            IFileRepository fileRepository,
            IWordMetadataRepository wordMetadataRepository,
            ILogger<CreateMetadataService> logger)
        {
            _fileRepository = fileRepository;
            _wordMetadataRepository = wordMetadataRepository;
            _logger = logger;
        }

        public async Task CreateWordMetadataAsync(CreateWordMetadataCommandModel createCommand)
        {
            var addedWords =await _wordMetadataRepository.GetAllWordsAsync();
            
            await using var fileStream = await _fileRepository.GetFileAsync(createCommand.FileId);
            using var parser = new TextFieldParser(fileStream);

            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = false;
            parser.TrimWhiteSpace = true;
            
            var headerFields = parser.ReadFields();
            var indexMap = GetFieldsIndexMap(headerFields);
            var addedWordSet = addedWords.ToHashSet();
            var wordsMetadata = new List<WordMetadataModel>();
            
            while (parser.PeekChars(1) != null)
            {
                var rowCells = parser.ReadFields();
                if (rowCells == null)
                {
                    continue;
                }

                var englishLevelField = rowCells[indexMap[MetadataFileColumns.Level]];
                var word = rowCells[indexMap[MetadataFileColumns.BaseWord]];
                if (addedWordSet.Contains(word))
                {
                    continue;
                }
                
                var metadata = new WordMetadataModel
                {
                    Word = word,
                    GuideWord = rowCells[indexMap[MetadataFileColumns.GuideWord]],
                    Level = EnglishLevelMapInternal[englishLevelField],
                    POS = rowCells[indexMap[MetadataFileColumns.POS]],
                    Topic = rowCells[indexMap[MetadataFileColumns.Topic]],
                };

                addedWordSet.Add(metadata.Word);
                wordsMetadata.Add(metadata);
            }

            await _wordMetadataRepository.AddAllAsync(wordsMetadata);
        }

        private IReadOnlyDictionary<string, int> GetFieldsIndexMap(string[] fields)
        {
            return new Dictionary<string, int>()
            {
                {
                    MetadataFileColumns.BaseWord,
                    Array.IndexOf(fields, MetadataFileColumns.BaseWord)
                },
                {
                    MetadataFileColumns.GuideWord,
                    Array.IndexOf(fields, MetadataFileColumns.GuideWord)
                },
                {
                    MetadataFileColumns.Level,
                    Array.IndexOf(fields, MetadataFileColumns.Level)
                },
                {
                    MetadataFileColumns.POS,
                    Array.IndexOf(fields, MetadataFileColumns.POS)
                },
                {
                    MetadataFileColumns.Topic,
                    Array.IndexOf(fields, MetadataFileColumns.Topic)
                },
            };
        }
    }
}