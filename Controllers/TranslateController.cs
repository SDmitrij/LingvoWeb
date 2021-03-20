using LingvoWeb.Models;
using LingvoWeb.Service;
using LingvoWeb.Service.Json;
using Microsoft.AspNetCore.Mvc;
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
            string json = await translator.GetTranslationJSON(request.ToTranslate, 
                (LanguageEnum)request.SrcLang, (LanguageEnum)request.DestLang, request.IsShort);
            var transRes = JsonSerializer.Deserialize<JsonShortResult>(json);
            return new JsonResult(transRes);
        }
    }
}
