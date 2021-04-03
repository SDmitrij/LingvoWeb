using LingvoWeb.Service;
using LingvoWeb.Service.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace LingvoWeb.Controllers
{
    [AllowAnonymous]
    public class TranslateController : BaseController
    {
        [HttpGet("get")]
        public async Task<ActionResult<string>> GetTranslation(
            string text, 
            string srcLang, 
            string dstLang, 
            bool isShort = true)
        {
            static bool validateTranslationRequest(
                string text, 
                string srcLang, 
                string dstLang)
            {
                return
                    !string.IsNullOrWhiteSpace(text) &&
                    !string.IsNullOrWhiteSpace(srcLang) &&
                    !string.IsNullOrWhiteSpace(dstLang);
            }

            if (!validateTranslationRequest(text, srcLang, dstLang))
                return new BadRequestObjectResult("There are empty or missing parameters.");

            if (!Enum.TryParse(srcLang, out LanguageEnum srcLangEnum)
            || !Enum.TryParse(dstLang, out LanguageEnum dstLangEnum))
                return new BadRequestObjectResult("Can't find required language.");
            
            string json =
                await Translator.GetTranslation(text, srcLangEnum, dstLangEnum, isShort);

            var transRes = JsonSerializer.Deserialize<JsonShortResult>(json).Translation.Translation;
            return Ok(transRes);
        }
    }
}
