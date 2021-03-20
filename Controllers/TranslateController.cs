using LingvoWeb.Models;
using LingvoWeb.Service;
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
            string json = await translator.GetTranslationJSON("keep", LanguageEnum.En, LanguageEnum.Ru, true);
            var transRes = JsonSerializer.Deserialize<ResultJsonShort>(json);
            return new JsonResult(transRes);
        }
    }
}
