using LingvoWeb.Service;
using LingvoWeb.Service.Json;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace LingvoWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslateController : ControllerBase
    {
        [HttpGet("get")]
        public async Task<JsonResult> GetTranslation(string text, string srcLang, string dstLang, bool isShort = true)
        {
            Console.WriteLine("Translate request {0} from {1} to {2}", text, srcLang, dstLang);

            if(!ValidateTranslationRequest(text, srcLang, dstLang))
            {
                Console.WriteLine("There is empty or missing parameters.");
                var res = new JsonResult("There is empty or missing parameters.")
                {
                    StatusCode = 400
                };
                return res;
            }

            if (!Enum.TryParse(srcLang, out LanguageEnum srcLangEnum)
            || !Enum.TryParse(dstLang, out LanguageEnum dstLangEnum))
            {
                Console.WriteLine("Wrong language.");
                var res = new JsonResult("Can't find required language.")
                {
                    StatusCode = 400
                };
                return res;
            }
            string json =
                await Translator.GetTranslation(text, srcLangEnum, dstLangEnum, isShort);

            var transRes = JsonSerializer.Deserialize<JsonShortResult>(json).Translation.Translation;

            return new JsonResult(transRes);
        }

        private bool ValidateTranslationRequest (string text, string srcLang, string dstLang)
        {
            return 
                !string.IsNullOrWhiteSpace(text) &&
                !string.IsNullOrWhiteSpace(srcLang) &&
                !string.IsNullOrWhiteSpace(dstLang);
        }
    }
}
