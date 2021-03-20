namespace LingvoWeb.Models
{
    public class TranslateRequest
    {
        public string ToTranslate { get; set; }
        public string SrcLang { get; set; }
        public string DstLang { get; set; }
        public bool IsShort { get; set; }
    }
}
