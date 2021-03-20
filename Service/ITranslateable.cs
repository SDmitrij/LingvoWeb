using System.Threading.Tasks;

namespace LingvoWeb.Service
{
    public interface ITranslateable
    {
        public Task<string> GetTranslation(
            string toTranslate,
            LanguageEnum srcLang,
            LanguageEnum dstLang,
            bool isShort = false);

        public Task Initialize();
    }
}
