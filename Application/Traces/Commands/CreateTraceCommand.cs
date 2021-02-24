
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Traces.Commands
{
    public class CreateTraceCommand : IRequest<int>
    {
        public string Url { get; set; }
        public DateTime DateOfAccess { get; set; }
    }
    public class CreateTraceCommandHandler : IRequestHandler<CreateTraceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateTraceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateTraceCommand command, CancellationToken cancellationToken)
        {
            var trace = new Trace();
            trace.Url = command.Url;
            trace.DateOfAccess = command.DateOfAccess;           
            _context.Traces.Add(trace);
            await _context.SaveChangesAsync();
            return trace.Id;
        }
    }

   
}
