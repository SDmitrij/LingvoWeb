using LingvoWeb.Service.Item;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LingvoWeb.Service.Json
{
    public class JsonLongResult
    {
        public string Title { get; set; }
        public ICollection<ArticleNode> TitleMarkup { get; set; }
        public string Dictionary { get; set; }
        public string ArticleId { get; set; }
        public ICollection<ArticleNode> Body { get; set; }

        public static explicit operator JsonResult(JsonLongResult v)
        {
            throw new NotImplementedException();
        }
    }
}
