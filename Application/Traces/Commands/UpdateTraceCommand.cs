using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Traces.Commands
{
    public class UpdateTraceCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime DateOfAccess { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateTraceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateTraceCommand command, CancellationToken cancellationToken)
        {
            var trace = _context.Traces.Where(a => a.Id == command.Id).FirstOrDefault();

            if (trace == null)
            {
                return default;
            }
            else
            {
                trace.Url = command.Url;
                trace.DateOfAccess = command.DateOfAccess;                
                await _context.SaveChangesAsync();
                return trace.Id;
            }
        }
    }
}
