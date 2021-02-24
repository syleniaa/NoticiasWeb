using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Traces.Commands
{
    public class DeleteTraceCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteTraceCommandHandler : IRequestHandler<DeleteTraceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public DeleteTraceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteTraceCommand command, CancellationToken cancellationToken)
        {
            var trace = await _context.Traces.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            if (trace == null) return default;
            _context.Traces.Remove(trace);
            await _context.SaveChangesAsync();
            return trace.Id;
        }
    }
}
