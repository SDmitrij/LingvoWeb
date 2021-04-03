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

    public enum NodeType : ushort
    {
        Comment = 0, //Комментарий
        Paragraph = 1, //Абзац
        Text = 2, //Простой текст
        List = 3, //Список
        ListItem = 4, //Элемент списка
        Examples = 5, //Примеры
        ExampleItem = 6, //Элемент списка примеров
        Example = 7, //Пример
        CardRefs = 8, //Ссылки на карточки
        CardRefItem = 9, //Элемент списка ссылок на карточки
        CardRef = 10, //Ссылка на карточку
        Transcription = 11, //Транскрипция
        Abbrev = 12, //Аббревиатура
        Caption = 13, //Заголовок
        Sound = 14, //Ссылка на звуковой файл
        Ref = 15, //Ссылка
        Unsupported = 16 //Неподдерживаемый тип элемента
    }
}
