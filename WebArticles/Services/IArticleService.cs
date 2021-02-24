using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebArticles.Data;

namespace WebArticles.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetNews(string city);
        //Task<IEnumerable<Article>> GetNews(string city);

    }
}
