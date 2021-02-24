using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebArticles.Data
{
    public class NewsResponse
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public IEnumerable<Article> articles {get;set;}
    }
}
