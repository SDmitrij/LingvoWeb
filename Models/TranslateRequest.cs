namespace LingvoWeb.Models
{
    public class TranslateRequest
    {
        public string ToTranslate;
        public ushort SrcLang;
        public ushort DestLang;
        public bool IsShort;
    }
}
