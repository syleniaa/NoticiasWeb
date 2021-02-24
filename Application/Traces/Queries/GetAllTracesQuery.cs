using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Traces.Queries
{
    public class GetAllTracesQuery : IRequest<IEnumerable<Trace>>
    {
    }

    public class GetAllTracesQueryHandler : IRequestHandler<GetAllTracesQuery, IEnumerable<Trace>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllTracesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Trace>> Handle(GetAllTracesQuery query, CancellationToken cancellationToken)
        {
            var tracesList = await _context.Traces.ToListAsync();
            if (tracesList == null)
            {
                return null;
            }
            return tracesList.AsReadOnly();
        }
    }
}
