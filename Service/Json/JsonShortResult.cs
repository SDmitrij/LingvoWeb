using LingvoWeb.Service.Item;
using System.Collections.Generic;

namespace LingvoWeb.Service.Json
{
    public class JsonShortResult
    {
        public LanguageEnum SourceLanguage { get; set; }
        public LanguageEnum TargetLanguage { get; set; }
        public string Heading { get; set; }
        public WordListItem Translation { get; set; }
        public ICollection<string> SeeAlso { get; set; }
    }
}
