using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;
using WebArticles.Data;

namespace WebArticles.Services
{
    public class ArticleService : IArticleService
    {
       
        private readonly HttpClient httpClient;

        public ArticleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Article>> GetNews(string city)
        {
            var response = await httpClient.GetJsonAsync<NewsResponse>("v2/everything?q=" + city);
            return response.articles;
            //return await httpClient.GetJsonAsync<Article[]>("/v2/everything?q=" + city);

        }
    }
}
