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
        [HttpPost("get")]
        public async Task<JsonResult> Get(TranslateRequest request)
        {
            Translate translator = new Translate();
            await translator.Initialize();
            if (!Enum.TryParse(request.SrcLang, out LanguageEnum srcLang)
            ||  !Enum.TryParse(request.DestLang, out LanguageEnum destLang))
            {
                var res = new JsonResult("Can't convert string to enum type")
                {
                    StatusCode = 400
                };
                return res;
            }
            string json = await translator.GetTranslationJSON(
                request.ToTranslate,
                srcLang,
                destLang,
                request.IsShort);

            var transRes = JsonSerializer.Deserialize<JsonShortResult>(json);
            return (JsonResult)transRes;
        }
    }
}
