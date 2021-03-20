namespace LingvoWeb.Models
{
    public class TranslateRequest
    {
        public string ToTranslate { get; set; }
        public string SrcLang { get; set; }
        public string DestLang { get; set; }
        public bool IsShort { get; set; }
    }
}
