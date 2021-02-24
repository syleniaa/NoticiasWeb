using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using WebArticles.Services;
using WebArticles.Data;
using System.Threading.Tasks;

namespace WebArticles.Pages
{
    public class ListTracesBase : ComponentBase 
    {
        [Inject]
        public ITraceService TraceService { get; set; }
        public IEnumerable<Trace> Traces { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Traces = (await TraceService.GetTraces());
        }
     }
}
