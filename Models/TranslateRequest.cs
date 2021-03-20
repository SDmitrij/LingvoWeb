namespace LingvoWeb.Models
{
    public class TranslateRequest
    {
        public string text { get; set; }
        public string srcLang { get; set; }
        public string dstLang { get; set; }
        public bool isShort { get; set; }
    }
}
