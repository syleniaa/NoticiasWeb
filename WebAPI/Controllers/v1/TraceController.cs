using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Traces.Queries;
using Application.Traces.Commands;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TraceController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTracesQuery()));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Create(CreateTraceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateTraceCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTraceCommand { Id = id }));
        }
    }
}
