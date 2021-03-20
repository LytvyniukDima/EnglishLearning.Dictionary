namespace EnglishLearning.Dictionary.Web.Contracts
{
    public class AddWordListDefinitionCommand
    {
        public string Word { get; set; }
        
        public WordDefinition WordDefinition { get; set; }
    }
}