using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;
using WebArticles.Data;

namespace WebArticles.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient httpClient;

        public LocationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Location> GetLocation()
        {
            Location location = await httpClient.GetJsonAsync<Location>("/json/");
            return location;
        }
    }
}
