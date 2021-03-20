using LingvoWeb.Models;
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
        public TranslateController()
        {
        }

        [HttpGet("get")]
        public async Task<JsonResult> GetTranslation(string text, string srcLang, string dstLang, bool isShort)
        {
            if (!Enum.TryParse(srcLang, out LanguageEnum srcLangEnum)
            || !Enum.TryParse(dstLang, out LanguageEnum dstLangEnum))
            {
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
    }
}
