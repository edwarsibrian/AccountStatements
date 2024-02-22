using AccountStatements.API.Commands;
using AccountStatements.API.Queries;
using AccountStatements.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountStatements.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SettingController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<Setting>GetSetting()
        {
            return await _mediator.Send(new GetSettingQuery());
        }

        [HttpPost]
        public async Task<Setting>CreateSetting(CreateSettingCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
