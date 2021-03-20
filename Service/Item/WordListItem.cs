namespace LingvoWeb.Service.Item
{
    public class WordListItem
    {
        public string Heading { get; set; }
        public string Translation { get; set; }
        public string DictionaryName { get; set; }
        public string SoundName { get; set; }
        public WordListItemType Type { get; set; }
        public string OriginalWord { get; set; }
    }
}
