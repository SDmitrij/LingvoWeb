namespace LingvoWeb.Service.Item
{
    public enum WordListItemType : ushort
    {
        None = 0,
        ExactWord = 1,
        LemmatizedVariant = 2,
        Subphrase = 4,
        SpellingVariant = 8,
        PrefixVariant = 16
    }
}
