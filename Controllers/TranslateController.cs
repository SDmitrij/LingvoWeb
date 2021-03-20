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
        private readonly ITranslateable _translator;

        public TranslateController(ITranslateable translator)
        {
            _translator = translator;
        }

        //[HttpPost("get")]
        //public async Task<JsonResult> Get(TranslateRequest request)
        //{
        //    await _translator.Initialize();
        //    if (!Enum.TryParse(request.SrcLang, out LanguageEnum srcLang)
        //    ||  !Enum.TryParse(request.DestLang, out LanguageEnum destLang))
        //    {
        //        var res = new JsonResult("Can't convert string to enum type")
        //        {
        //            StatusCode = 400
        //        };
        //        return res;
        //    }
        //    string json = await _translator.GetTranslation(
        //        request.ToTranslate,
        //        srcLang,
        //        destLang,
        //        request.IsShort);

        //    var transRes = JsonSerializer.Deserialize<JsonShortResult>(json);
        //    return (JsonResult)transRes;
        //}

        [HttpGet("get")]
        public async Task<JsonResult> Get(string toTran)
        {
            await _translator.Initialize();
            string res = await _translator.GetTranslation(toTran, LanguageEnum.En, LanguageEnum.Ru, true);
            return new JsonResult(res);
        }
    }
}
