using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebArticles.Data;


namespace WebArticles.Services
{
    public class TraceService : ITraceService
    {
        private readonly HttpClient HttpClient;

        public TraceService(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }


        public async Task<IEnumerable<Trace>> GetTraces()
        {           
            return await HttpClient.GetJsonAsync<Trace[]>("/api/v1/Trace");
        }

        public async void PostTrace(string url, DateTime date)
        {         
            await HttpClient.PostJsonAsync("/api/v1/Trace", new CreateTraceCommand { Url = url, DateOfAccess = date});             
        }
    }

    public class CreateTraceCommand
    {
        public string Url { get; set; }
        public DateTime DateOfAccess { get; set; }
    }
}
