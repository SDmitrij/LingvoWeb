using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LingvoWeb.Service.Item
{
    public class ArticleNode
    {
        public NodeType Node { get; set; }
        public string Text { get; set; }
        public bool IsOptional { get; set; }
    }
}
