using LingvoWeb.Models;
using LingvoWeb.Service;
using LingvoWeb.Service.Json;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace LingvoWeb.Controllers
{

    public class TranslateController : ControllerBase
    {
        [HttpGet]
        public async Task<JsonResult> Get(TranslateRequest request)
        {
            Translate translator = new Translate();
            await translator.Initialize();
            if (!Enum.TryParse(request.SrcLang, out LanguageEnum srcLang)
            || !Enum.TryParse(request.SrcLang, out LanguageEnum destLang))
            {
                return ;
            }
            string json = await translator.GetTranslationJSON(
                request.ToTranslate, 
                srcLang, 
                destLang,
                request.IsShort);
            
            var transRes = JsonSerializer.Deserialize<JsonShortResult>(json).Translation.Translation;
            return new JsonResult(transRes);
        }
    }
}
