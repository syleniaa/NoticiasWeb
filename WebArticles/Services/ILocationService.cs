using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebArticles.Data;

namespace WebArticles.Services
{
    public interface ILocationService
    {
        Task<Location> GetLocation();

    }
}
