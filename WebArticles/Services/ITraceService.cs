using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebArticles.Data;

namespace WebArticles.Services
{
    public interface ITraceService
    {
        Task<IEnumerable<Trace>> GetTraces();

        void PostTrace(string url , DateTime date);
    }
}
