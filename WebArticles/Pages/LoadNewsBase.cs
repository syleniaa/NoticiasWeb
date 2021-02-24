using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebArticles.Data;
using WebArticles.Services;

namespace WebArticles.Pages
{
    public class LoadNewsBase : ComponentBase
    {
        [CascadingParameter] public IModalService Modal { get; set; }

        [Inject]
        public ILocationService LocationService { get; set; }
        public string city { get; set; }
        [Inject]
        public ITraceService TraceService { get; set; }

        [Inject]
        public IArticleService ArticleService { get; set; }
        public IEnumerable<Article> Articles { get; set; }

        protected override async Task OnInitializedAsync()
        {
            city = (await LocationService.GetLocation()).City;
            Articles = (await ArticleService.GetNews(city));
            TraceService.PostTrace("http://newsapi.org/v2/everything?q=" + city, DateTime.Now);
        }

        public void ShowDetail(Article article)
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(ArticleDetail.Article), article);

            Modal.Show<ArticleDetail>(article.Title, parameters);
        }
    }
}
